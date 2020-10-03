CREATE PROCEDURE [orden_owner].[QRY_SCRN_MERCADOS_GRID_MAIN_ALL]
@Codigo VARCHAR(20) = NULL,
@Descripcion VARCHAR(50) = NULL,
@PageNumber BIGINT = NULL, 
@PageSize BIGINT = 0
AS
BEGIN 
	;WITH pg AS (
					SELECT Codigo as Codigo,
						   Descripcion as Descripcion,
						   IdMercado as IdMercado,
						   EsInterno,
						   ProductoHabilitadoDefecto,
						   COUNT(1) OVER() AS TotalRows
					FROM        
						  shared_owner.Mercados m
					WHERE
						(@Codigo IS NULL OR m.Codigo LIKE + '%' + @Codigo + '%')
					AND (@Descripcion IS NULL OR m.Descripcion LIKE + '%' + @Descripcion + '%' )
					ORDER BY m.IdMercado ASC 
					OFFSET @PageSize * (@PageNumber - 1) ROWS
					FETCH NEXT @PageSize ROWS ONLY
				)
	SELECT pg.* FROM pg ORDER BY pg.IdMercado;
END
