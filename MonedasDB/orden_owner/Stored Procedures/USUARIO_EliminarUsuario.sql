CREATE PROCEDURE [orden_owner].[USUARIO_EliminarUsuario]
( 
    @IdUsuario INT
)    
AS
BEGIN
	SET NOCOUNT ON 
	
	UPDATE 
		shared_owner.Usuarios
	SET   
		BajaLogica = 1,
		FechaBaja = GETDATE()
	WHERE  
		IdUsuario = @IdUsuario

END
