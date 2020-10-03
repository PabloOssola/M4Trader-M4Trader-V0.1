CREATE PROCEDURE [orden_owner].[QRY_SCRN_ESTADOS_FILTERS_BUNDLE]
AS
BEGIN
	
	SELECT Descripcion as NombreEstado, IdEstadoOrden  FROM orden_owner.EstadosOrden

END