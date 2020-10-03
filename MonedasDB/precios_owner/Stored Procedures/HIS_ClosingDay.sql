CREATE PROCEDURE [precios_owner].[HIS_ClosingDay]
@IdProducto INT = NULL,
@FechaDesde DATETIME = NULL,
@FechaHasta DATETIME = NULL
AS
BEGIN
		SELECT  hcd.IdHistoricoCierresDia,
				hcd.FechaDesde,
				hcd.FechaHasta,
				hcd.IdMoneda,
				m.Codigo AS Moneda,
				hcd.MontoOperado,
				hcd.Cantidad,
				hcd.PrecioCierre,
				hcd.PrecioApertura,
				hcd.PrecioMinimo,
				hcd.PrecioMaximo,
				p.Codigo AS Producto
		FROM  precios_owner.HistoricoCierresDia hcd
		INNER JOIN shared_owner.Monedas m ON (m.IdMoneda = hcd.IdMoneda)
		INNER JOIN orden_owner.Productos p ON (p.IdProducto = hcd.IdProducto)
		WHERE 
			(@IdProducto IS NULL OR hcd.IdProducto = @IdProducto)
			AND (@FechaDesde IS NULL OR hcd.FechaDesde >= @FechaDesde)
			AND (@FechaHasta IS NULL OR hcd.FechaDesde <= @FechaHasta)
		ORDER BY hcd.FechaDesde
END