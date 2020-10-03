CREATE PROCEDURE [precios_owner].[HIS_ClosingWeek]
@IdProducto INT = NULL,
@FechaDesde DATETIME = NULL,
@FechaHasta DATETIME = NULL
AS
BEGIN
		SELECT  hcs.IdHistoricoCierresSemana,
				hcs.FechaDesde,
				hcs.FechaHasta,
				hcs.IdMoneda,
				m.Codigo AS Moneda,
				hcs.MontoOperado,
				hcs.Cantidad,
				hcs.PrecioCierre,
				hcs.PrecioApertura,
				hcs.PrecioMinimo,
				hcs.PrecioMaximo,
				p.Codigo AS Producto
		FROM  precios_owner.HistoricoCierresSemana hcs
		INNER JOIN shared_owner.Monedas m ON (m.IdMoneda = hcs.IdMoneda)
		INNER JOIN orden_owner.Productos p ON (p.IdProducto = hcs.IdProducto)
		WHERE 	(@IdProducto IS NULL OR hcs.IdProducto = @IdProducto)
			AND (@FechaDesde IS NULL OR hcs.FechaDesde >= @FechaDesde)
			AND (@FechaHasta IS NULL OR hcs.FechaDesde <= @FechaHasta)
		ORDER BY hcs.FechaDesde
END