CREATE PROCEDURE [precios_owner].[HIS_Closing60Min]
@IdProducto INT = NULL,
@FechaDesde DATETIME = NULL,
@FechaHasta DATETIME = NULL
AS
BEGIN
--- Cambiar la fecha hora todo junto en la generacion del llenado de la tabla
		SELECT  hc60m.IdHistoricoCierres60Min,
				CAST(CAST (Fecha AS VARCHAR(10)) + ' ' 
				+ SUBSTRING(CAST(FORMAT(HoraDesde,'D6') AS VARCHAR(6)), 1, 2) + ':'
				+ SUBSTRING(CAST(FORMAT(HoraDesde,'D6') AS VARCHAR(6)), 3, 2) + ':'
				+ SUBSTRING(CAST(FORMAT(HoraDesde,'D6') AS VARCHAR(6)), 5, 2) AS DATETIME)as FechaDesde,
				hc60m.HoraDesde AS FechaHasta,
			--	hc60m.HoraHasta,
				hc60m.IdMoneda,
				m.Codigo AS Moneda,
				hc60m.MontoOperado,
				hc60m.Cantidad,
				hc60m.PrecioCierre,
				hc60m.PrecioApertura,
				hc60m.PrecioMinimo,
				hc60m.PrecioMaximo,
				p.Codigo AS Producto
		FROM  precios_owner.HistoricoCierres60Min hc60m
		INNER JOIN shared_owner.Monedas m ON (m.IdMoneda = hc60m.IdMoneda)
		INNER JOIN orden_owner.Productos p ON (p.IdProducto = hc60m.IdProducto)
		WHERE 
			(@IdProducto IS NULL OR hc60m.IdProducto = @IdProducto)
			AND (@FechaDesde IS NULL OR hc60m.Fecha >= @FechaDesde)
			AND (@FechaHasta IS NULL OR hc60m.Fecha <= @FechaHasta)
			ORDER BY hc60m.Fecha, hc60m.HoraDesde 
END