CREATE PROCEDURE orden_owner.QRY_SCRN_USUARIOS_GRID_MAIN_ALL
@IdUsuario int,
@input_filtro_primario varchar(50)=null,
@Username varchar(20)=null,
@Nombre varchar(50)=null,
@PageNumber int=NULL, 
@PageSize int=0
AS
BEGIN 
    SET NOCOUNT ON;

	;WITH pg AS
		(
		SELECT  
			u.IdUsuario as IdUsuario,        
            u.Username as UserName,    
            u.Pass as Pass,    
            u.Nombre as Nombre,    
            u.Expiracion as Expiracion,    
            u.FechaBaja as FechaBaja,    
            u.CantidadIntentos as CantidadIntentos,    
            u.Bloqueado as Bloqueado,    
            u.Proceso as Proceso,    
            u.NoControlarInactividad AS NoControlarInactividad,    
            u.UltimaModificacionPassword as UltimaModificacionPassword,    
            u.UltimoLoginExitoso as UltimoLoginExitoso,    
            u.UltimaActualizacion as UltimaActualizacion,  
			u.IdPersona as IdPersona,  
			p.Name as NombrePersona,
			u.FechaReactivacion AS FechaReactivacion,
			u.BajaLogica AS BajaLogica,
			COUNT(1) OVER() AS TotalRows
		FROM shared_owner.Usuarios u
			INNER JOIN shared_owner.Parties p ON (p.IdParty = u.IdPersona)
		WHERE u.IdUsuario not in (1, 2)
			AND (@Nombre is null OR u.Nombre like '%' + UPPER(@Nombre) + '%')  
			AND (@Username is null OR u.Username like '%' + UPPER(@Username) + '%') 
		ORDER BY IdUsuario
		OFFSET @PageSize * (@PageNumber - 1) ROWS
		FETCH NEXT @PageSize ROWS ONLY
	  )
   
    SELECT * from pg
	
END
