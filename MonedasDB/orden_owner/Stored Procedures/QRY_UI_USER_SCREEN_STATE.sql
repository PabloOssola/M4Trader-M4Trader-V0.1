CREATE PROCEDURE [orden_owner].[QRY_UI_USER_SCREEN_STATE]
	@IdUsuario INT=NULL,
	@NombrePantalla VARCHAR(255)=NULL
AS
BEGIN
	SELECT	 
		Codigo,
		Valor
	   FROM shared_owner.CustomizacionUsuario
	   WHERE ([IdUsuario] = @IdUsuario)
	   AND ((@NombrePantalla IS NULL) OR ( [Codigo] = @NombrePantalla)) 
END