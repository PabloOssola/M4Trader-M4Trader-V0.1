CREATE PROCEDURE orden_owner.QRY_SCRN_AUDITORIA_GRID_MAIN_ALL
@IdUsuario int,
@Entidad varchar(100),
@IdRegistro bigint = NULL,
@PageNumber int = NULL, 
@PageSize int = 0
AS
BEGIN
	SET NOCOUNT ON;

	;WITH pg AS
		(
			SELECT  IdLogAuditoria,
			l.FechaEvento,
			u.Username as UserName, 
			p.Name as NombrePersona, 
			CASE l.TipoEvento when 0 then 'Alta'else 'Modificación' end as TipoEvento, 
			lc.NombreEntidad, 
			lc.NombreClase, 
			COUNT(1) OVER() AS TotalRows 
			from shared_owner.LogAuditoria l
			INNER JOIN shared_owner.Usuarios u on u.IdUsuario = l.IdUsuario
			INNER JOIN shared_owner.Parties p on p.IdParty = u.IdPersona
			INNER JOIN shared_owner.LogAuditoriaClases lc on lc.IdLogAuditoriaClase = l.IdClase
			WHERE lc.NombreEntidad=@Entidad AND (@IdRegistro IS NULL OR l.IdRegistro = @IdRegistro)
			ORDER BY FechaEvento desc OFFSET @PageSize * (@PageNumber - 1) ROWS FETCH NEXT @PageSize ROWS ONLY
		)
	
	SELECT * FROM pg
END
