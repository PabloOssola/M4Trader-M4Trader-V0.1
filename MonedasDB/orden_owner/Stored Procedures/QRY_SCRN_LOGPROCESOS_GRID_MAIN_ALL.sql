CREATE PROCEDURE [orden_owner].[QRY_SCRN_LOGPROCESOS_GRID_MAIN_ALL]
	@IdUsuario INT = NULL, 
	@Descripcion VARCHAR(max)= NULL,
	@Resultado VARCHAR(max)= NULL,
	@RequestId VARCHAR(max) = NULL, 
	@FechaDesde DATETIME = NULL, 
	@FechaHasta DATETIME = NULL, 
    @PageNumber INT = NULL, 
    @PageSize INT = NULL
AS
BEGIN 

IF @FechaDesde IS NOT NULL
	set @FechaDesde = shared_owner.fn_ARQ_ConvertirFechaAHoraInicial(@FechaDesde)

IF @FechaHasta IS NOT NULL
	set @FechaHasta = shared_owner.fn_ARQ_ConvertirFechaAHoraFinal(@FechaHasta)

	;WITH pg AS (  SELECT  c.[IdLogProceso]
						  ,c.[IdUsuario]
						  ,u.[Nombre]
						  ,c.[Fecha]
						  ,c.[Descripcion]
						  ,c.[Resultado]
						  ,c.[RequestId]
						  ,c.[IdLogCodigoAccion]
						  ,COUNT(1) OVER() AS TotalRows 
					  FROM [orden_owner].[LogProcesos] c
					LEFT JOIN shared_owner.Usuarios u on u.IdUsuario = c.IdUsuario   
					WHERE 
						((@IdUsuario IS NULL) OR (u.IdUsuario = @IdUsuario))    
						AND ((@FechaDesde IS NULL) OR (c.Fecha >= @FechaDesde))
						AND ((@FechaHasta IS NULL) OR (c.Fecha < @FechaHasta))
						AND (@Descripcion IS NULL OR c.Descripcion LIKE '%'+ @Descripcion + '%')
						AND (@Resultado IS NULL OR c.Resultado LIKE '%'+ @Resultado + '%')
						AND (@RequestId IS NULL OR CAST(c.RequestId AS VARCHAR(200)) LIKE '%' + @RequestId + '%')
					ORDER BY IdLogProceso DESC
						OFFSET @PageSize * (@PageNumber - 1) ROWS
						FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT pg.* FROM pg;
END