CREATE PROCEDURE [precios_owner].[HIS_ClosingMonth]
@IdProducto INT = NULL,
@FechaDesde DATETIME = NULL,
@FechaHasta DATETIME = NULL
AS
BEGIN 
		SELECT  hcm.IdHistoricoCierresMes,
				hcm.FechaDesde,
				hcm.FechaHasta,
				hcm.IdMoneda,
				m.Codigo AS Moneda,
				hcm.MontoOperado,
				hcm.Cantidad,
				hcm.PrecioCierre,
				hcm.PrecioApertura,
				hcm.PrecioMinimo,
				hcm.PrecioMaximo,
				p.Codigo AS Producto
		FROM  precios_owner.HistoricoCierresMes hcm
		INNER JOIN shared_owner.Monedas m ON (m.IdMoneda = hcm.IdMoneda)
		INNER JOIN orden_owner.Productos p ON (p.IdProducto = hcm.IdProducto)
		WHERE 
			(@IdProducto IS NULL OR hcm.IdProducto = @IdProducto)
			AND (@FechaDesde IS NULL OR hcm.FechaDesde >= @FechaDesde)
			AND (@FechaHasta IS NULL OR hcm.FechaDesde <= @FechaHasta)
		ORDER BY hcm.FechaDesde
END