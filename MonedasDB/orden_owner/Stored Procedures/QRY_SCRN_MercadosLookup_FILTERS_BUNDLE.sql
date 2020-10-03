CREATE PROCEDURE [orden_owner].[QRY_SCRN_MercadosLookup_FILTERS_BUNDLE]  
@Codigo VARCHAR(10) = NULL,  
@IdMercado INT = NULL,  
@Descripcion VARCHAR(100) = NULL,
@PageNumber bigint = NULL,   
@PageSize BIGINT = 0,
@query VARCHAR(50) = NULL
  
AS  
BEGIN   
 ;WITH pg AS (  
     SELECT  
      m.IdMercado AS IdMercado 
	 ,m.Codigo AS Codigo
	 ,m.Descripcion AS Descripcion
	 ,COUNT(1) OVER() AS TotalRows
	FROM  shared_owner.Mercados m
     WHERE
		(@Codigo IS NULL OR m.Codigo LIKE + '%' + @Codigo + '%')
	AND (@Descripcion IS NULL OR m.Descripcion LIKE + '%' + @Descripcion + '%')
	AND (@IdMercado IS NULL OR m.IdMercado = @IdMercado)
	AND (@query IS NULL OR m.Codigo  LIKE + '%' + @query + '%')
     ORDER BY m.IdMercado ASC   
     OFFSET @PageSize * (@PageNumber - 1) ROWS  
     FETCH NEXT @PageSize ROWS ONLY  
    )  
      
 SELECT pg.* FROM pg;  
END