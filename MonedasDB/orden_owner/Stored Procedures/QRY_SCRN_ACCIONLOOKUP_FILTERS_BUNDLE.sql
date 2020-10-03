CREATE PROCEDURE orden_owner.QRY_SCRN_ACCIONLOOKUP_FILTERS_BUNDLE
@NombreAccion varchar(100) =NULL,
@IdAccion smallint =NULL,
@PageNumber int,
@PageSize int
AS  
BEGIN  

;WITH pg AS (
				SELECT  
				e.IdAccion as IdAccion,
				e.Descripcion AS NombreAccion,
				COUNT(1) OVER() AS TotalRows
				FROM shared_owner.Acciones e 
				WHERE (@IdAccion is NULL OR e.IdAccion = @IdAccion)
				AND (@NombreAccion is NULL OR e.Descripcion like  '%' + @NombreAccion + '%')
				ORDER BY e.IdAccion DESC
				OFFSET @PageSize * (@PageNumber - 1) ROWS
				FETCH NEXT @PageSize ROWS ONLY
				)
	SELECT pg.* FROM pg ORDER BY pg.IdAccion

END
