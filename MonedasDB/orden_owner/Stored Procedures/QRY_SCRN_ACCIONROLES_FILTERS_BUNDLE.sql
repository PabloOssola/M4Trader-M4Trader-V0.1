CREATE PROCEDURE orden_owner.QRY_SCRN_ACCIONROLES_FILTERS_BUNDLE
AS
BEGIN 
	
	SELECT 0 as Orden, 'IdRol' as NombreCampo
	UNION SELECT 1 as Orden, 'IdAccion' as NombreCampo
	
	Order by Orden

	SELECT '-- Todos --' as NombreRol, 0 as 'IdRol'
	UNION SELECT Descripcion as NombreRol, IdRol as 'IdRol'
	FROM shared_owner.Roles where BajaLogica = 0

	SELECT '-- Todos --' as NombreAccion, 0 as 'IdAccion'
	UNION SELECT Descripcion as NombreAccion, IdAccion as 'IdAccion'
	FROM shared_owner.Acciones

END