CREATE PROCEDURE orden_owner.QRY_SCRN_AUDITORIA_DETALLE_GRID_MAIN_ALL
@IdLogAuditoria bigint,
@PageNumber int=NULL, 
@PageSize int=0
AS
	
	SET NOCOUNT ON;

	;WITH pg AS
		(
			SELECT  l.IdLogAuditoria,
			l.ValorOriginal,
			l.ValorNuevo,  
			COUNT(1) OVER() AS TotalRows 
			from shared_owner.LogAuditoria l
			WHERE l.IdLogAuditoria = @IdLogAuditoria
			ORDER BY IdLogAuditoria OFFSET @PageSize * (@PageNumber - 1) ROWS FETCH NEXT @PageSize ROWS ONLY
		)
	
	SELECT * FROM pg