CREATE PROCEDURE orden_owner.SEG_GETALLPERMISOSBYUSUARIO  
@IdUsuario int
AS  
BEGIN  

		SELECT  
			   us.IdUsuario, 
			   ar.IdAccion,  
			   MAX(ar.Permiso) as Permisos
		   FROM   
			   shared_owner.Usuarios us  
			   INNER JOIN shared_owner.RolUsuario ru on us.IdUsuario = ru.IdUsuario 
			   INNER JOIN shared_owner.AccionRol ar on ru.IdRol = ar.IdRol 
		   WHERE  
			   us.IdUsuario = @IdUsuario  
			   AND us.BajaLogica = 0  
		GROUP BY  us.IdUsuario, 
			   ar.IdAccion
END  
