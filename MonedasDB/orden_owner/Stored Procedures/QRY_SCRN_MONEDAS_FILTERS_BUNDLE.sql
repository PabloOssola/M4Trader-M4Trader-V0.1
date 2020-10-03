CREATE PROCEDURE orden_owner.QRY_SCRN_MONEDAS_FILTERS_BUNDLE
AS
BEGIN
	
	SELECT 0 as Orden, 'TipoMoneda' as NombreCampo
	Order by Orden
 
	SELECT '-- Todas --' as NombreTipoMoneda, 0 as 'TipoMoneda'
	UNION SELECT Descripcion, IdTipoMoneda FROM shared_owner.TiposMoneda

END