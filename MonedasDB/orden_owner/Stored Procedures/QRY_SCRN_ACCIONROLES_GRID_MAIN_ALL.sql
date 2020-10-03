CREATE PROCEDURE orden_owner.QRY_SCRN_ACCIONROLES_GRID_MAIN_ALL
    @IdRol varchar(100)=NULL,
	@IdAccion varchar(100)=NULL,
    @PageNumber bigint=NULL, 
    @PageSize bigint=0
	 
AS
BEGIN 
	;WITH accionRoles AS (
					select ar.IdAccionRol as IdAccionRol, r.Descripcion as Rol, a.Descripcion as Accion, ar.UltimaActualizacion AS UltimaActualizacion,
cast((1	& Permiso) as bit) as Consulta,
cast((2	& Permiso)/2 as bit) as Salidas,
cast((4	& Permiso)/4 as bit) as Modificacion,
cast((8	& Permiso)/8 as bit) as Baja,
cast((16	& Permiso)/16 as bit) as Alta,
cast((32	& Permiso)/32 as bit) as Supervision,
cast((64	& Permiso)/64 as bit) as Importacion,
cast((128 & Permiso)/128 as bit) as Aprobacion_Automatica,
cast((256 & Permiso)/256 as bit) as Ejecucion,
cast((512 & Permiso)/512 as bit) as Consulta_Log_Operativo,
COUNT(1) OVER() AS TotalRows
FROM shared_owner.AccionRol ar
INNER JOIN shared_owner.Roles r on ar.IdRol = r.IdRol 
INNER JOIN shared_owner.Acciones a on ar.IdAccion = a.IdAccion
WHERE (@IdRol is null OR r.IdRol = @IdRol)
AND (@IdAccion is null OR a.IdAccion = @IdAccion)
					ORDER BY ar.IdAccionRol ASC 
					OFFSET @PageSize * (@PageNumber - 1) ROWS
					FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT * FROM accionRoles;
END
