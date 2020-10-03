CREATE PROCEDURE orden_owner.QRY_SCRN_LOGAUDITORIA_GRID_MAIN_ALL    
	@IdUsuario int = NULL,
	@IdLogAuditoriaClase int = NULL,
	@FechaDesde DATETIME = null,
	@FechaHasta DATETIME = null,
	@IdTipoEvento int = null,
	@PageNumber int=NULL, 
    @PageSize int=0
AS
	
	SET NOCOUNT ON;

	if @FechaDesde is not null
		set @FechaDesde = shared_owner.fn_ARQ_ConvertirFechaAHoraInicial(@FechaDesde)
	
		
	if @FechaHasta is not null
		set @FechaHasta = shared_owner.fn_ARQ_ConvertirFechaAHoraFinal(@FechaHasta)


	;WITH pg AS
		(
			SELECT  IdLogAuditoria,
			l.FechaEvento,
			u.Username as UserName, 
			p.Name as NombrePersona, 
			CASE l.TipoEvento 
				when 0 then 'Alta'
				when 1 then 'Eliminación'
				else 'Modificación' 
			end as TipoEvento, 
			lc.NombreEntidad, 
			lc.NombreClase, 
			COUNT(1) OVER() AS TotalRows 
			FROM shared_owner.LogAuditoria l
			INNER JOIN shared_owner.Usuarios u on u.IdUsuario = l.IdUsuario
			INNER JOIN shared_owner.Parties p on p.IdParty = u.IdPersona
			INNER JOIN shared_owner.LogAuditoriaClases lc on lc.IdLogAuditoriaClase = l.IdClase
			WHERE (lc.IdLogAuditoriaClase = @IdLogAuditoriaClase OR @IdLogAuditoriaClase IS NULL) 
			and (@IdUsuario IS NULL OR u.IdUsuario = @IdUsuario)
			and ((@FechaDesde IS NULL OR FechaEvento >= @FechaDesde) AND (@FechaHasta IS NULL OR FechaEvento <= @FechaHasta))
			AND (@IdTipoEvento = l.TipoEvento OR @IdTipoEvento IS NULL)
			ORDER BY FechaEvento desc OFFSET @PageSize * (@PageNumber - 1) ROWS FETCH NEXT @PageSize ROWS ONLY
		)
	
	SELECT * FROM pg
GO
