CREATE PROCEDURE [precios_owner].[HIS_ActualizarDatos]
@IdProducto INT,
@IdMoneda TINYINT,
@Precio DECIMAL(18, 8),
@Cantidad DECIMAL(18, 4)
AS
BEGIN 
  DECLARE @FechaHoy DATE
  DECLARE @HoraAhora INT
  DECLARE @HoraDesde INT
  SELECT @FechaHoy = GETDATE(), @HoraAhora = REPLACE(CAST(convert(varchar(10), GETDATE(), 108) AS varchar(MAX)),':', '')

  --Actualizo tabla Mes
  IF (1 > (SELECT COUNT(1) FROM precios_owner.HistoricoCierresMes WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda AND FechaHasta >= @FechaHoy))
  BEGIN
	INSERT INTO precios_owner.HistoricoCierresMes (FechaDesde, FechaHasta, IdProducto, IdMoneda, MontoOperado, Cantidad, PrecioCierre, PrecioApertura, PrecioMinimo, PrecioMaximo) 
	VALUES (DATEADD(DAY,1,EOMONTH(@FechaHoy,-1)), EOMONTH(@FechaHoy,0), @IdProducto, @IdMoneda, @Precio, @Cantidad, @Precio, @Precio, @Precio, @Precio)
  END
  ELSE
  BEGIN
	UPDATE precios_owner.HistoricoCierresMes 
	SET MontoOperado = MontoOperado + @Precio, 
	Cantidad = Cantidad + @Cantidad, 
	PrecioMinimo = IIF(PrecioMinimo < @Precio, PrecioMinimo, @Precio), 
	PrecioMaximo = IIF(PrecioMaximo > @Precio, PrecioMaximo, @Precio)
	WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda  AND FechaHasta >= @FechaHoy
  END
  
  --Actualizo tabla Semana
  IF (1 > (SELECT COUNT(1) FROM precios_owner.HistoricoCierresSemana WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda AND FechaHasta >= @FechaHoy))
  BEGIN
	INSERT INTO precios_owner.HistoricoCierresSemana (FechaDesde, FechaHasta, IdProducto, IdMoneda, MontoOperado, Cantidad, PrecioCierre, PrecioApertura, PrecioMinimo, PrecioMaximo) 
	VALUES (DATEADD(DAY, 2-DATEPART(WEEKDAY, @FechaHoy), @FechaHoy), DATEADD(DAY, 8-DATEPART(WEEKDAY, @FechaHoy), @FechaHoy), @IdProducto, @IdMoneda, @Precio, @Cantidad, @Precio, @Precio, @Precio, @Precio)
  END
  ELSE
  BEGIN
	UPDATE precios_owner.HistoricoCierresSemana
	SET MontoOperado = MontoOperado + @Precio, 
	Cantidad = Cantidad + @Cantidad, 
	PrecioMinimo = IIF(PrecioMinimo < @Precio, PrecioMinimo, @Precio), 
	PrecioMaximo = IIF(PrecioMaximo > @Precio, PrecioMaximo, @Precio)
	WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda  AND FechaHasta >= @FechaHoy
  END
  
  --Actualizo tabla Dia
  IF (1 > (SELECT COUNT(1) FROM precios_owner.HistoricoCierresDia WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda AND FechaHasta >= @FechaHoy))
  BEGIN
	INSERT INTO precios_owner.HistoricoCierresDia (FechaDesde, FechaHasta, IdProducto, IdMoneda, MontoOperado, Cantidad, PrecioCierre, PrecioApertura, PrecioMinimo, PrecioMaximo) 
	VALUES (@FechaHoy, @FechaHoy, @IdProducto, @IdMoneda, @Precio, @Cantidad, @Precio, @Precio, @Precio, @Precio)
  END
  ELSE
  BEGIN
	UPDATE precios_owner.HistoricoCierresDia 
	SET MontoOperado = MontoOperado + @Precio, 
	Cantidad = Cantidad + @Cantidad, 
	PrecioMinimo = IIF(PrecioMinimo < @Precio, PrecioMinimo, @Precio), 
	PrecioMaximo = IIF(PrecioMaximo > @Precio, PrecioMaximo, @Precio)
	WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda  AND FechaHasta >= @FechaHoy
  END
  
  --Actualizo tabla 30 Miuntos
  SELECT @HoraDesde = CASE WHEN (@HoraAhora % 10000) > 3000 THEN (@HoraAhora - ((@HoraAhora % 10000) - 3000)) ELSE (@HoraAhora - ((@HoraAhora % 10000))) END
  IF (1 > (SELECT COUNT(1) FROM precios_owner.HistoricoCierres30Min WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda AND Fecha = @FechaHoy AND HoraHasta >= @HoraAhora))
  BEGIN
	INSERT INTO precios_owner.HistoricoCierres30Min (Fecha, HoraDesde, HoraHasta, IdProducto, IdMoneda, MontoOperado, Cantidad, PrecioCierre, PrecioApertura, PrecioMinimo, PrecioMaximo) 
	VALUES (@FechaHoy, @HoraDesde, @HoraDesde + 3000, @IdProducto, @IdMoneda, @Precio, @Cantidad, @Precio, @Precio, @Precio, @Precio)
  END
  ELSE
  BEGIN
	UPDATE precios_owner.HistoricoCierres30Min 
	SET MontoOperado = MontoOperado + @Precio, 
	Cantidad = Cantidad + @Cantidad, 
	PrecioMinimo = IIF(PrecioMinimo < @Precio, PrecioMinimo, @Precio), 
	PrecioMaximo = IIF(PrecioMaximo > @Precio, PrecioMaximo, @Precio)
	WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda  AND Fecha = @FechaHoy AND HoraHasta >= @HoraAhora
  END

    --Actualizo tabla 60 Miuntos
  IF (1 > (SELECT COUNT(1) FROM precios_owner.HistoricoCierres60Min WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda AND Fecha = @FechaHoy AND HoraHasta >= @HoraAhora))
  BEGIN
	INSERT INTO precios_owner.HistoricoCierres60Min (Fecha, HoraDesde, HoraHasta, IdProducto, IdMoneda, MontoOperado, Cantidad, PrecioCierre, PrecioApertura, PrecioMinimo, PrecioMaximo) 
	VALUES (@FechaHoy, @HoraAhora - ((@HoraAhora % 10000)), @HoraAhora - ((@HoraAhora % 10000) - 6000), @IdProducto, @IdMoneda, @Precio, @Cantidad, @Precio, @Precio, @Precio, @Precio)
  END
  ELSE
  BEGIN
	UPDATE precios_owner.HistoricoCierres60Min 
	SET MontoOperado = MontoOperado + @Precio, 
	Cantidad = Cantidad + @Cantidad, 
	PrecioMinimo = IIF(PrecioMinimo < @Precio, PrecioMinimo, @Precio), 
	PrecioMaximo = IIF(PrecioMaximo > @Precio, PrecioMaximo, @Precio)
	WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda  AND Fecha = @FechaHoy AND HoraHasta >= @HoraAhora
  END
END