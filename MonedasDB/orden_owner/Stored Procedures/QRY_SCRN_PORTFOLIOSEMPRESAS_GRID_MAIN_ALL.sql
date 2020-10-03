CREATE PROCEDURE [orden_owner].[QRY_SCRN_PORTFOLIOSEMPRESAS_GRID_MAIN_ALL]
@Nombre VARCHAR(50) = NULL,
@Codigo VARCHAR(5) = NULL,
@IdUsuario int,
@PageNumber bigint = NULL, 
@PageSize bigint = 0
--,@EsDeSistema VARCHAR(100) = NULL

AS
BEGIN 
	;WITH pg AS (
				    SELECT
					*
					FROM(
					SELECT
					p.IdPortfolio
					,p.Nombre AS Nombre
					,p.Codigo AS Codigo
					,p.EsDeSistema AS EsDeSistema
					FROM
					orden_owner.Portfolios p
					INNER JOIN orden_owner.PortfolioUsuario pu  ON p.IdPortfolio = pu.IdPortfolio
					WHERE
				    (@Nombre IS NULL OR p.Nombre LIKE + '%' + @Nombre + '%')
					AND
				    (@Codigo IS NULL OR p.Codigo LIKE + '%' + @Codigo + '%')
					AND
					(@IdUsuario IS NULL OR pu.IdUsuario = @IdUsuario)
					) portfolios
					ORDER BY portfolios.IdPortfolio ASC 
					OFFSET @PageSize * (@PageNumber - 1) ROWS
					FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT pg.* FROM pg;
END