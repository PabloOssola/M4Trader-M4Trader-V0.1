CREATE PROCEDURE [orden_owner].[USUARIO_ActualizarUsuario]
( 
    @IdUsuario INT,
	@Nombre VARCHAR(50),
	@Bloqueado BIT,
	@LimiteOferta DECIMAL,
	@LimiteOperacion DECIMAL
)    
AS
BEGIN
	SET NOCOUNT ON 
	
	UPDATE  u
	SET 
		u.Nombre = @Nombre, 
		u.Bloqueado = @Bloqueado
	FROM 
		shared_owner.Usuarios u
		INNER JOIN shared_owner.UsuariosLimites ul on ul.IdUsuario = u.IdUsuario
	WHERE  
		u.IdUsuario = @IdUsuario

	
	--Update de Limites
	UPDATE  ul
	SET 
		ul.LimiteOferta = @LimiteOferta, 
		ul.LimiteOperacion = @LimiteOperacion
	FROM 
		shared_owner.Usuarios u
		INNER JOIN shared_owner.UsuariosLimites ul on ul.IdUsuario = u.IdUsuario
	WHERE  
		u.IdUsuario = @IdUsuario

END
