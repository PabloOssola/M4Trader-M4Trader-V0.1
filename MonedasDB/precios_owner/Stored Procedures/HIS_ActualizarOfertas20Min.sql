CREATE PROCEDURE [precios_owner].[HIS_ActualizarOfertas20Min]
@IdProducto INT,
@IdMoneda TINYINT,
@PrecioCompra DECIMAL(18, 8),
@PrecioVenta DECIMAL(18, 8),
@FechaHoy DATE,
@IdPlazo TINYINT,
@Rueda Varchar(5),
@IdMercado TINYINT
AS
BEGIN
  DECLARE @HoraAhora INT
  DECLARE @HoraDesde INT
  DECLARE @HoraHasta INT
  SELECT @HoraAhora = REPLACE(CAST(convert(varchar(10), GETDATE(), 108) AS varchar(MAX)),':', '')
  select @FechaHoy = isnull(@FechaHoy,getdate())
  --precio compra - precio venta - desde - hasta - key
  --Actualizo tabla 20 Miuntos
  SELECT @HoraDesde =  STUFF(@HoraAhora,5,2,'00')
  SELECT @HoraHasta = case when  @HoraDesde%10000=5900 then (@HoraDesde + 10000 - 5900 ) else (@HoraDesde + 100) end
  IF not exists (SELECT * FROM precios_owner.HistoricoOfertas20Min WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda AND Fecha = @FechaHoy AND Rueda = @Rueda AND HoraHasta = @HoraHasta AND HoraDesde = @HoraDesde)
  BEGIN
  --hora desde es el hasta anterior
	  if(@PrecioCompra is null)
	  begin
		select @PrecioCompra = PrecioCompra from precios_owner.HistoricoOfertas20Min
		WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda  and IdPlazo = @IdPlazo and IdMercado = @IdMercado and Rueda = @Rueda AND Fecha = @FechaHoy AND HoraHasta = @HoraDesde
	  end
  --hora desde es el hasta anterior
	if(@PrecioVenta is null)
	  begin
		select @PrecioVenta = PrecioVenta from precios_owner.HistoricoOfertas20Min
		WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda  and IdPlazo = @IdPlazo and IdMercado = @IdMercado and Rueda = @Rueda AND Fecha = @FechaHoy AND HoraHasta = @HoraDesde
	end
	INSERT INTO precios_owner.HistoricoOfertas20Min (Fecha, HoraDesde, HoraHasta, PrecioCompra, PrecioVenta, IdProducto, IdMoneda, IdPlazo, Rueda, IdMercado)
	VALUES (@FechaHoy, @HoraDesde, @HoraHasta, @PrecioCompra, @PrecioVenta, @IdProducto, @IdMoneda, @IdPlazo, @Rueda, @IdMercado)
  END
  ELSE
  BEGIN
	UPDATE precios_owner.HistoricoOfertas20Min
	SET
	PrecioCompra = IIF(PrecioCompra > isnull(@PrecioCompra,0), PrecioCompra, @PrecioCompra),
	PrecioVenta = IIF(PrecioVenta <= isnull(@PrecioVenta,PrecioVenta) , PrecioVenta, @PrecioVenta)
	WHERE IdProducto = @IdProducto AND IdMoneda = @IdMoneda  and IdPlazo = @IdPlazo and IdMercado = @IdMercado and Rueda = @Rueda AND Fecha = @FechaHoy AND HoraHasta >= @HoraAhora
  END
END