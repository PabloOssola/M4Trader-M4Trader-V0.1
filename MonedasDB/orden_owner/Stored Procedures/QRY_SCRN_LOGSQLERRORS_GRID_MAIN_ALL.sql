CREATE PROCEDURE orden_owner.QRY_SCRN_LOGSQLERRORS_GRID_MAIN_ALL
	@IdUsuario INT = NULL, 
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

	;WITH pg AS (  SELECT   IdLogSqlErrores,
							u.Nombre,
							TipoSentenciaSQL,
							NombreSP,
							ParametrosSP,
							MensajeError,
							Fecha,
							RequestId,
							COUNT(1) OVER() AS TotalRows
					FROM orden_owner.LogSqlErrores s
					LEFT JOIN shared_owner.Usuarios u on u.IdUsuario = s.IdUsuario
					WHERE 
						    ((@IdUsuario IS NULL) OR (u.IdUsuario = @IdUsuario))    
						AND ((@RequestId IS NULL) OR (RequestId = @RequestId))    
						AND ((@FechaDesde IS NULL) OR (s.Fecha >= @FechaDesde))
						AND ((@FechaHasta IS NULL) OR (s.Fecha < @FechaHasta))
					ORDER BY IdLogSqlErrores DESC
						OFFSET @PageSize * (@PageNumber - 1) ROWS
						FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT pg.* FROM pg;
END
