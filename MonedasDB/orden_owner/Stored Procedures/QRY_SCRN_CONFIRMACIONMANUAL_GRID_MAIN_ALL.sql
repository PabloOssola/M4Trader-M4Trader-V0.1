CREATE PROCEDURE [orden_owner].[QRY_SCRN_CONFIRMACIONMANUAL_GRID_MAIN_ALL]
@IdUsuario smallint = NULL,
@PageNumber bigint = 1, 
@PageSize bigint = 10

AS
BEGIN 
	;WITH pg AS (
					SELECT  cm.IdConfirmacionManual,
							--sa.Descripcion as SourcesApplication,
							pa.Name as Persona,
							p.Codigo as Producto,
							COUNT(1) OVER() AS TotalRows
					FROM orden_owner.ConfirmacionManual cm
					--INNER JOIN orden_owner.SourcesApplication sa ON sa.IdSourceApplication = cm.IdSourceApplication 
					INNER JOIN shared_owner.Parties pa ON pa.IdParty = cm.IdParty
					INNER JOIN orden_owner.Productos p ON p.IdProducto = cm.IdProducto
					ORDER BY IdConfirmacionManual ASC 
					OFFSET @PageSize * (@PageNumber - 1) ROWS
					FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT pg.* FROM pg;
END

