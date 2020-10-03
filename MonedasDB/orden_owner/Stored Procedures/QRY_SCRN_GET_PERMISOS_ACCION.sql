CREATE PROCEDURE orden_owner.QRY_SCRN_GET_PERMISOS_ACCION
@IdAccion int
AS
BEGIN
	SELECT HabilitarPermisos 
	FROM shared_owner.Acciones
	WHERE IdAccion = @IdAccion
END