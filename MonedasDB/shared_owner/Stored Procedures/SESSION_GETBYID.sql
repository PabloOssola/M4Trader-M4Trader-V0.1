CREATE PROCEDURE [shared_owner].[SESSION_GETBYID]  
@IdSesion		uniqueidentifier
AS  
BEGIN  
		SELECT * FROM shared_owner.Sesiones
		WHERE  IdSesion = @IdSesion
END