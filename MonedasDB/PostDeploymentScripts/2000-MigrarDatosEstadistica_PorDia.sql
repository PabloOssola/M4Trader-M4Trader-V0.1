/*  EJECUTAR SOLO SI ES PARA MIGRAR DATOS DE ESTADISTICA

USE SIOPEL_1001
ALTER TABLE Siopel_1001.siopel_owner.swoper_historico ADD FechaAlterada DATETIME NULL
PRINT 'ALTER TABLE'
GO
UPDATE Siopel_1001.siopel_owner.swoper_historico SET FechaAlterada = CAST(CONVERT(VARCHAR,FECHA,112) AS DATETIME)
PRINT 'UPDATE'
CREATE NONCLUSTERED INDEX IX_swoper_historico6 ON siopel_owner.swoper_historico
(
	codigodeti,FechaAlterada, rueda, Estado, moneda, tipo
) include (FECHA) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
PRINT 'CREATE INDEX'
GO

USE SORFIX_Limpia

DECLARE @FechaInicial DATETIME
DECLARE @Moneda1 VARCHAR(1)
DECLARE @Moneda2 VARCHAR(1)
DECLARE @IdMoneda TINYINT
DECLARE @IdProducto INT
DECLARE @RuedaExcludia VARCHAR(4)
DECLARE @EstadoOperaciones VARCHAR(1)
DECLARE @Contador INT
DECLARE @IdTipoProducto TINYINT

SELECT @FechaInicial = '141231', @RuedaExcludia = 'REPO', @EstadoOperaciones = 'S', @Contador = 0
SELECT TOP 1 @IdTipoProducto = IdTipoProducto FROM orden_owner.TiposProducto WHERE Descripcion = 'Bonos'

/*****VALORES PARA PESOS*****/
SELECT @Moneda1 = '$', @Moneda2 = 'T', @IdMoneda = IdMoneda FROM shared_owner.Monedas WHERE Codigo = '$'

/*****VALORES PARA DOLARES*****/
--SELECT @Moneda1 = 'D', @Moneda2 = 'X', @IdMoneda = IdMoneda FROM shared_owner.Monedas WHERE Codigo = 'D'

INSERT INTO [orden_owner].[Productos] (Codigo, IdMoneda, Habilitado, IdTipoProducto) 
SELECT 
	  DISTINCT (hc.codigodeti), @IdMoneda, 0, @IdTipoProducto
FROM [LINK_SERVER_SIOPEL].Siopel_1001.siopel_owner.swoper_historico hc
  WHERE hc.Fecha > @FechaInicial 
  AND hc.rueda != @RuedaExcludia AND Estado = @EstadoOperaciones
  and hc.moneda in (@Moneda1,@Moneda2) and not tipo in ('@', '+','=')
  AND NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE Codigo COLLATE SQL_Latin1_General_CP1_CI_AS = hc.codigodeti AND IdMoneda = @IdMoneda)
  GROUP BY hc.codigodeti
  ORDER BY hc.codigodeti

SELECT 
	  FECHA Fecha
      ,hc.codigodeti CodigoProducto
      ,@Moneda1 CodigoMoneda
      ,SUM(hc.PRECIOOPER) MontoOperado
      ,SUM(hc.CANTIDADOP) Cantidad
      ,MIN(hc.PRECIOOPER) PrecioMinimo
      ,MAX(hc.PRECIOOPER) PrecioMaximo 
	  ,MAX(hc.PRECIOOPER) PrecioCierre --Solo para crear la columna
	  ,MIN(hc.PRECIOOPER) PrecioApertura --Solo para crear la columna
	  ,@IdMoneda IdMoneda
	  ,p.IdProducto
  INTO #AuxTablasCrear
  FROM [LINK_SERVER_SIOPEL].Siopel_1001.siopel_owner.swoper_historico hc
  INNER JOIN orden_owner.Productos p ON p.Codigo COLLATE SQL_Latin1_General_CP1_CI_AS = hc.codigodeti AND p.IdMoneda = @IdMoneda
  WHERE hc.Fecha > @FechaInicial 
  AND hc.rueda != @RuedaExcludia AND Estado = @EstadoOperaciones
  and hc.moneda in (@Moneda1,@Moneda2) and not tipo in ('@', '+','=')
  GROUP BY hc.FECHA, hc.codigodeti, p.IdProducto
  ORDER BY hc.FECHA, hc.codigodeti, p.IdProducto


  SELECT * FROM #AuxTablasCrear 

Declare @Fecha DateTime
Declare @CodigoProducto VARCHAR(15)
Declare @CodigoMoneda  VARCHAR(1)
DECLARE @PrecioApertura DECIMAL(18,8)
DECLARE @PrecioCierre DECIMAL(18,8)

DECLARE MiCursor CURSOR FOR SELECT Fecha, IdProducto, CodigoProducto, CodigoMoneda FROM #AuxTablasCrear
OPEN MiCursor
FETCH NEXT FROM MiCursor INTO @Fecha, @IdProducto, @CodigoProducto, @CodigoMoneda
WHILE @@FETCH_STATUS = 0
BEGIN
	SELECT @PrecioApertura = hc.PRECIOOPER FROM [LINK_SERVER_SIOPEL].Siopel_1001.siopel_owner.swoper_historico hc
		WHERE hc.Fecha = @Fecha AND hc.rueda != @RuedaExcludia AND Estado = @EstadoOperaciones
				and hc.moneda in (@Moneda1,@Moneda2) and not tipo in ('@', '+','=') AND hc.codigodeti = @CodigoProducto
			and NOT EXISTS (SELECT 1 FROM [LINK_SERVER_SIOPEL].Siopel_1001.siopel_owner.swoper_historico hc2
		WHERE hc2.Fecha = @Fecha AND hc2.rueda != @RuedaExcludia AND hc2.Estado = @EstadoOperaciones
				and hc2.moneda in (@Moneda1,@Moneda2) and not hc2.tipo in ('@', '+','=') AND hc2.codigodeti = @CodigoProducto AND hc.Hora > hc2.Hora)

	SELECT @PrecioCierre = hc.PRECIOOPER FROM [LINK_SERVER_SIOPEL].Siopel_1001.siopel_owner.swoper_historico hc
		WHERE hc.Fecha = @Fecha AND hc.rueda != @RuedaExcludia AND Estado = @EstadoOperaciones
				and hc.moneda in (@Moneda1,@Moneda2) and not tipo in ('@', '+','=') AND hc.codigodeti = @CodigoProducto
			and NOT EXISTS (SELECT 1 FROM [LINK_SERVER_SIOPEL].Siopel_1001.siopel_owner.swoper_historico hc2
		WHERE hc2.Fecha = @Fecha AND hc2.rueda != @RuedaExcludia AND hc2.Estado = @EstadoOperaciones
				and hc2.moneda in (@Moneda1,@Moneda2) and not hc2.tipo in ('@', '+','=') AND hc2.codigodeti = @CodigoProducto AND hc.Hora < hc2.Hora)

	SET @Contador = @Contador + 1
	SELECT @IdProducto = IdProducto FROM orden_owner.Productos WHERE IdMoneda = @IdMoneda AND Codigo = @CodigoProducto
	UPDATE #AuxTablasCrear SET PrecioApertura = @PrecioApertura, PrecioCierre = @PrecioCierre WHERE Fecha = @Fecha AND IdProducto = @IdProducto AND CodigoProducto = @CodigoProducto AND CodigoMoneda = @CodigoMoneda
	if (@Contador % 50 = 0)
	BEGIN
		PRINT 'UPDATE ' + CAST(@Contador AS VARCHAR) + ' registros'
	END
	FETCH NEXT FROM MiCursor INTO @Fecha, @IdProducto, @CodigoProducto, @CodigoMoneda
END
CLOSE MiCursor
DEALLOCATE MiCursor   

PRINT 'UPDATE ' + CAST(@Contador AS VARCHAR) + ' registros'

INSERT INTO precios_owner.HistoricoCierresDia (FechaDesde, FechaHasta, IdProducto, IdMoneda, MontoOperado, Cantidad, PrecioCierre, PrecioApertura, PrecioMinimo, PrecioMaximo) 
SELECT 
CAST(CONVERT(VARCHAR,FECHA,112) AS DATETIME), CAST(DATEADD(ms, -2, DATEADD(dd, 1, CONVERT(VARCHAR, Fecha, 112))) AS DATETIME), IdProducto, IdMoneda,
MontoOperado, Cantidad, PrecioCierre, PrecioApertura, PrecioMinimo, PrecioMaximo
FROM #AuxTablasCrear

DROP TABLE #AuxTablasCrear
*/