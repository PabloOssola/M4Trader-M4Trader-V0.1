CREATE PROCEDURE orden_owner.QRY_SCRN_MONEDAS_GRID_MAIN_ALL
@Descripcion VARCHAR(50) = NULL,
@Codigo VARCHAR(8) = NULL,
@TipoMoneda TINYINT = NULL,
@PageNumber BIGINT = NULL, 
@PageSize BIGINT = 0
	 
AS
BEGIN 
	;WITH Monedas AS (
					SELECT
						 m.IdMoneda as IdMoneda 
						,m.Codigo as Codigo 
						,m.Descripcion as Descripcion
						,t.Descripcion as TipoMoneda
						,COUNT(1) OVER() AS TotalRows
					FROM  shared_owner.Monedas m
					INNER JOIN shared_owner.TiposMoneda AS t ON m.TipoMoneda = t.IdTipoMoneda
					WHERE 
						(@Descripcion IS NULL OR m.Descripcion LIKE + '%' + @Descripcion + '%')
					AND (@Codigo IS NULL OR m.Codigo LIKE + '%' + @Codigo + '%')
					AND (@TipoMoneda IS NULL OR m.TipoMoneda = @TipoMoneda)
					ORDER BY m.IdMoneda ASC 
					OFFSET @PageSize * (@PageNumber - 1) ROWS
					FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT Monedas.* FROM Monedas;
END
