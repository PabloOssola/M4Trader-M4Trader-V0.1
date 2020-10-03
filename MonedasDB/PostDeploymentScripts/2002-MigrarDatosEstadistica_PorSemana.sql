/*  EJECUTAR SOLO SI ES PARA MIGRAR DATOS DE ESTADISTICA 

DECLARE @FechaInicial DATETIME
DECLARE @FechaMinima DATETIME
DECLARE @FechaMaxima DATETIME
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
  WHERE CAST(CONVERT(VARCHAR,cast((round(hc.Fecha/100,0,1)*100) + 1 as INT),112) AS DATETIME) > @FechaInicial 
  AND hc.rueda != @RuedaExcludia AND Estado = @EstadoOperaciones
  and hc.moneda in (@Moneda1,@Moneda2) and not tipo in ('@', '+','=')
  AND NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE Codigo COLLATE SQL_Latin1_General_CP1_CI_AS = hc.codigodeti AND IdMoneda = @IdMoneda)
  GROUP BY hc.codigodeti
  ORDER BY hc.codigodeti

SELECT 
	  DATEADD(wk, DATEDIFF(wk, 0,CAST(CONVERT(VARCHAR,FECHA,112) AS DATETIME)),0) Fecha
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
  WHERE CAST(CONVERT(VARCHAR,cast((round(hc.Fecha/100,0,1)*100) + 1 as INT),112) AS DATETIME) > @FechaInicial 
  AND hc.rueda != @RuedaExcludia AND Estado = @EstadoOperaciones
  and hc.moneda in (@Moneda1,@Moneda2) and not tipo in ('@', '+','=')
  GROUP BY DATEADD(wk, DATEDIFF(wk, 0,CAST(CONVERT(VARCHAR,FECHA,112) AS DATETIME)),0), hc.codigodeti, p.IdProducto
  ORDER BY DATEADD(wk, DATEDIFF(wk, 0,CAST(CONVERT(VARCHAR,FECHA,112) AS DATETIME)),0), hc.codigodeti, p.IdProducto


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
	SELECT @FechaMinima = MIN(FECHA) FROM Siopel_1001.siopel_owner.swoper_historico hc
	WHERE FechaAlterada >= @Fecha AND FechaAlterada < dateadd(dd,7, @Fecha) 
		AND hc.rueda != @RuedaExcludia AND Estado = @EstadoOperaciones
		and hc.moneda in (@Moneda1,@Moneda2) and not tipo in ('@', '+','=') AND hc.codigodeti = @CodigoProducto

	SELECT @FechaMaxima = MAX(FECHA) FROM Siopel_1001.siopel_owner.swoper_historico hc
	WHERE FechaAlterada >= @Fecha AND FechaAlterada < dateadd(dd,7, @Fecha) 
		AND hc.rueda != @RuedaExcludia AND Estado = @EstadoOperaciones
		and hc.moneda in (@Moneda1,@Moneda2) and not tipo in ('@', '+','=') AND hc.codigodeti = @CodigoProducto

	SELECT @PrecioApertura = hc.PRECIOOPER FROM Siopel_1001.siopel_owner.swoper_historico hc
		WHERE hc.Fecha = @FechaMinima AND hc.rueda != @RuedaExcludia AND Estado = @EstadoOperaciones
				and hc.moneda in (@Moneda1,@Moneda2) and not tipo in ('@', '+','=') AND hc.codigodeti = @CodigoProducto
			and NOT EXISTS (SELECT 1 FROM Siopel_1001.siopel_owner.swoper_historico hc2
		WHERE hc2.Fecha = @FechaMinima AND hc2.rueda != @RuedaExcludia AND hc2.Estado = @EstadoOperaciones
				and hc2.moneda in (@Moneda1,@Moneda2) and not hc2.tipo in ('@', '+','=') AND hc2.codigodeti = @CodigoProducto AND hc.Hora > hc2.Hora)

	SELECT @PrecioCierre = hc.PRECIOOPER FROM Siopel_1001.siopel_owner.swoper_historico hc
		WHERE hc.Fecha = @FechaMaxima AND hc.rueda != @RuedaExcludia AND Estado = @EstadoOperaciones
				and hc.moneda in (@Moneda1,@Moneda2) and not tipo in ('@', '+','=') AND hc.codigodeti = @CodigoProducto
			and NOT EXISTS (SELECT 1 FROM Siopel_1001.siopel_owner.swoper_historico hc2
		WHERE hc2.Fecha = @FechaMaxima AND hc2.rueda != @RuedaExcludia AND hc2.Estado = @EstadoOperaciones
				and hc2.moneda in (@Moneda1,@Moneda2) and not hc2.tipo in ('@', '+','=') AND hc2.codigodeti = @CodigoProducto AND hc.Hora < hc2.Hora)

	SET @Contador = @Contador + 1
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

INSERT INTO precios_owner.HistoricoCierresSemana (FechaDesde, FechaHasta, IdProducto, IdMoneda, MontoOperado, Cantidad, PrecioCierre, PrecioApertura, PrecioMinimo, PrecioMaximo) 
SELECT 
Fecha, DATEADD(ms, -2, DATEADD(dd, 7, Fecha)), IdProducto, IdMoneda,
MontoOperado, Cantidad, PrecioCierre, PrecioApertura, PrecioMinimo, PrecioMaximo
FROM #AuxTablasCrear

DROP TABLE #AuxTablasCrear
*/