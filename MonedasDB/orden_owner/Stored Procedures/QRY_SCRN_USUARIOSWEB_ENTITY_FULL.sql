CREATE PROCEDURE orden_owner.QRY_SCRN_USUARIOSWEB_ENTITY_FULL
@IdUsuario INT
AS
BEGIN 
    SET NOCOUNT ON;
    
SELECT  u.IdUsuario as IdUsuario,                   
		u.Username as Username, 
		u.Nombre as Name,    
		u.IdPersona as IdPersona,
		u.Email as Email
    FROM        
		  shared_owner.Usuarios u
    WHERE   
		  u.IdUsuario = @IdUsuario
END