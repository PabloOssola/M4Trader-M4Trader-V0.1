CREATE PROCEDURE [precios_owner].[HIS_ObtenerOfertas20Min]
@CodigoProducto VARCHAR(50),
@Moneda VARCHAR(50),
@Rueda VARCHAR(50),
@Plazo VARCHAR(50),
@Mercado VARCHAR(50)
AS
BEGIN
		SELECT  hist.PrecioCompra AS precioofc,
				hist.PrecioVenta AS precioofv,
				hist.HoraHasta AS secuencia
		FROM  precios_owner.HistoricoOfertas20Min hist
				INNER JOIN orden_owner.Productos p on (p.IdProducto = hist.IdProducto)
				INNER JOIN shared_owner.Monedas mon on (mon.IdMoneda = hist.IdMoneda)
				INNER JOIN orden_owner.Plazos pla on (pla.IdPlazo = hist.IdPlazo)
				INNER JOIN shared_owner.Mercados merc on (merc.IdMercado = hist.IdMercado)
		WHERE mon.Descripcion = @Moneda
			AND p.Codigo = @CodigoProducto
			AND p.SegmentMarketId = @Rueda
			AND pla.Descripcion = @Plazo
			AND merc.Codigo = @Mercado 
END