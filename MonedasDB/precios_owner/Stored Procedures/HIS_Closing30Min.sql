CREATE PROCEDURE [precios_owner].[HIS_Closing30Min]
@IdProducto INT = NULL,
@FechaDesde DATETIME = NULL,
@FechaHasta DATETIME = NULL
AS
BEGIN
--- Cambiar la fecha hora todo junto en la generacion del llenado de la tabla
		SELECT  hc30m.IdHistoricoCierres30Min,
				CAST(CAST (Fecha AS VARCHAR(10)) + ' ' 
				+ SUBSTRING(CAST(FORMAT(HoraDesde,'D6') AS VARCHAR(6)), 1, 2) + ':'
				+ SUBSTRING(CAST(FORMAT(HoraDesde,'D6') AS VARCHAR(6)), 3, 2) + ':'
				+ SUBSTRING(CAST(FORMAT(HoraDesde,'D6') AS VARCHAR(6)), 5, 2) AS DATETIME)as FechaDesde,
				hc30m.HoraDesde AS FechaHasta,
		--		hc30m.HoraHasta,
				hc30m.IdMoneda,
				m.Codigo AS Moneda,
				hc30m.MontoOperado,
				hc30m.Cantidad,
				hc30m.PrecioCierre,
				hc30m.PrecioApertura,
				hc30m.PrecioMinimo,
				hc30m.PrecioMaximo,
				p.Codigo AS Producto
		FROM  precios_owner.HistoricoCierres30Min hc30m
		INNER JOIN shared_owner.Monedas m ON (m.IdMoneda = hc30m.IdMoneda)
		INNER JOIN orden_owner.Productos p ON (p.IdProducto = hc30m.IdProducto)
		WHERE 
			(@IdProducto IS NULL OR hc30m.IdProducto = @IdProducto)
			AND (@FechaDesde IS NULL OR hc30m.Fecha >= @FechaDesde)
			AND (@FechaHasta IS NULL OR hc30m.Fecha <= @FechaHasta)
			ORDER BY hc30m.Fecha, hc30m.HoraDesde
END