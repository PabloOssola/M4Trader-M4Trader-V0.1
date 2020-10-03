CREATE PROCEDURE orden_owner.QRY_SCRN_LOGCOMANDOS_GRID_MAIN_ALL
	@IdUsuario INT = NULL, 
	@Comando VARCHAR(max)= NULL,
	@RequestId UNIQUEIDENTIFIER = NULL, 
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

	;WITH pg AS (  SELECT IdLogCommand,
						   u.Nombre,
						   CommandName,
						   Codigo,
						   StartDateTime AS Fecha,
						   RequestId,
						   Argument,
						   COUNT(1) OVER() AS TotalRows
					FROM orden_owner.LogCommand c
					LEFT JOIN shared_owner.Usuarios u on u.IdUsuario = c.IdUsuario   
					WHERE Codigo not in ('CMD-OK','QUERY-OK')
						AND ((@IdUsuario IS NULL) OR (u.IdUsuario = @IdUsuario))    
						AND ((@RequestId IS NULL) OR (RequestId = @RequestId))    
						AND ((@FechaDesde IS NULL) OR (c.StartDateTime >= @FechaDesde))
						AND ((@FechaHasta IS NULL) OR (c.StartDateTime < @FechaHasta))
						AND ((@Comando IS NULL) OR (c.CommandName like '%' + @Comando + '%' ))
					ORDER BY IdLogCommand DESC
						OFFSET @PageSize * (@PageNumber - 1) ROWS
						FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT pg.* FROM pg;
END