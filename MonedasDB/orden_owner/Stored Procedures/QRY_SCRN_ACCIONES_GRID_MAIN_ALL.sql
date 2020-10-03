CREATE PROCEDURE orden_owner.QRY_SCRN_ACCIONES_GRID_MAIN_ALL
    @Descripcion varchar(100)=NULL,
    @PageNumber bigint=NULL, 
    @PageSize bigint=0
	 
AS
BEGIN 
	;WITH acciones AS (
					select IdAccion as IdAccion, a.Descripcion as Descripcion,
						cast((1	& HabilitarPermisos) as bit) as Consulta,
						cast((2	& HabilitarPermisos)/2 as bit) as Salidas,
						cast((4	& HabilitarPermisos)/4 as bit) as Modificacion,
						cast((8	& HabilitarPermisos)/8 as bit) as Baja,
						cast((16	& HabilitarPermisos)/16 as bit) as Alta,
						cast((64	& HabilitarPermisos)/64 as bit) as Importacion,
						cast((128 & HabilitarPermisos)/128 as bit) as Aprobacion_Automatica,
						cast((256 & HabilitarPermisos)/256 as bit) as Ejecucion,
						COUNT(1) OVER() AS TotalRows
						from shared_owner.Acciones a 
						where (@Descripcion is null OR a.Descripcion like '%' + @Descripcion + '%')
											ORDER BY a.IdAccion ASC 
											OFFSET @PageSize * (@PageNumber - 1) ROWS
											FETCH NEXT @PageSize ROWS ONLY
										)
				
	SELECT * FROM acciones;
END
