CREATE PROCEDURE [orden_owner].[QRY_SCRN_PORTFOLIOSLOOKUP_FILTERS_BUNDLE]  
@Nombre VARCHAR(50) = NULL,
@PageNumber bigint = NULL, 
@PageSize bigint = 0,
@query varchar(50) = NULL,
@EsDeSistema VARCHAR(100) = NULL
  
AS  
BEGIN 
	;WITH pg AS (
					SELECT
					p.IdPortfolio
					,p.Nombre AS Nombre
					,p.Codigo AS Codigo
					,p.EsDeSistema AS EsDeSistema
					FROM
					orden_owner.Portfolios p 
					WHERE
				    (@Nombre IS NULL OR p.Nombre LIKE + '%' + @Nombre + '%')
					AND (@query IS NULL OR p.Nombre LIKE + '%' + @query + '%')
					AND (@EsDeSistema IS NULL OR p.EsDeSistema = @EsDeSistema)
					ORDER BY p.IdPortfolio ASC 
					OFFSET @PageSize * (@PageNumber - 1) ROWS
					FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT pg.* FROM pg;
END