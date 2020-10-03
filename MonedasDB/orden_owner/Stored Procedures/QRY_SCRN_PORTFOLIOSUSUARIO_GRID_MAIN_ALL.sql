CREATE PROCEDURE [orden_owner].[QRY_SCRN_PORTFOLIOSUSUARIO_GRID_MAIN_ALL]
@IdUsuario smallint = NULL,
@PageNumber bigint = 1, 
@PageSize bigint = 10

AS
BEGIN 
	;WITH pg AS (
					SELECT
						 pu.IdPortfolioUsuario,
						 pu.IdPortfolio,
						 po.Nombre,
						 po.Codigo AS Codigo,
						 po.EsDeSistema,
						 pu.PorDefecto,
						 COUNT(1) OVER() AS TotalRows
					FROM  orden_owner.PortfolioUsuario pu
					INNER JOIN orden_owner.Portfolios po ON pu.IdPortfolio = po.IdPortfolio
					WHERE
					(@IdUsuario IS NULL OR pu.IdUsuario = @IdUsuario)
					ORDER BY pu.IdUsuario ASC 
					OFFSET @PageSize * (@PageNumber - 1) ROWS
					FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT pg.* FROM pg;
END