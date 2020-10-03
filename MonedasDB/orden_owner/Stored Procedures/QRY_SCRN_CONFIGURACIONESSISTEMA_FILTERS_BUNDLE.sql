CREATE PROCEDURE orden_owner.QRY_SCRN_CONFIGURACIONESSISTEMA_FILTERS_BUNDLE
AS
BEGIN
	
	SELECT 0 as Orden, 'TipoUrl' as NombreCampo
	Order by Orden
 
	SELECT '-- Seleccione --' as NombreUrl, 0 as 'TipoUrl'
	UNION ALL SELECT 'Mobile' as NombreUrl, 1 as 'TipoUrl'
	UNION SELECT 'Swift' as NombreUrl, 2 as 'TipoUrl'
	UNION SELECT 'RabbitQueue' AS NombreUrl, 3 as 'TipoUrl'
	UNION SELECT 'RabbitMobile' AS NombreUrl, 4 as 'TipoUrl'
	UNION SELECT 'OrdenesFIX' AS NombreUrl, 5 as 'TipoUrl'
	UNION SELECT 'DoubleAuthentication' AS NombreUrl, 6 as 'TipoUrl'

END