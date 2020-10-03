CREATE PROCEDURE [orden_owner].[QRY_CONSULTAR_PORTFOLIOCOMPOSICION_GRID_MAIN]
@IdPortfolio smallint = NULL,
@PageNumber bigint = NULL, 
@PageSize bigint = 0

AS
BEGIN 
	;WITH pg AS (
					SELECT
						 pc.IdPortfoliosComposicion
						,p.IdProducto AS IdProducto
						,pc.IdPortfolio 
						,pc.IdMercado
						,p.Codigo AS CodigoProducto
						,p.Descripcion AS DescripcionProducto
						,p.IdMoneda AS IdMoneda
						,m.Descripcion AS Moneda
						,me.Codigo AS Mercados
						,pl.Descripcion AS Plazo
						,pc.Orden
						,pc.IdPlazo
						,COUNT(1) OVER() AS TotalRows
					FROM  orden_owner.PortfoliosComposicion pc
					INNER JOIN orden_owner.Productos p ON pc.IdProducto = p.IdProducto
					INNER JOIN shared_owner.Monedas m ON p.IdMoneda = m.IdMoneda
					INNER JOIN orden_owner.Portfolios po ON pc.IdPortfolio = po.IdPortfolio
					INNER JOIN shared_owner.Mercados me ON pc.IdMercado = me.IdMercado
					INNER JOIN orden_owner.Plazos pl ON pc.IdPlazo = pl.IdPlazo
					WHERE
					(@IdPortfolio IS NULL OR po.IdPortfolio = @IdPortfolio)
					ORDER BY pc.IdPortfolio, pc.Orden ASC--, pc.IdMercado, pc.IdProducto, pc.IdPlazo ASC 
					OFFSET @PageSize * (@PageNumber - 1) ROWS
					FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT pg.* FROM pg;
END