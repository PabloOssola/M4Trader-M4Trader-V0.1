CREATE PROCEDURE orden_owner.QRY_SCRN_ROLES_GRID_MAIN_ALL
@Descripcion varchar(100)=null,
@ValorNumerico smallint=null,
@PageNumber bigint=NULL, 
@PageSize bigint=0
	 
AS
BEGIN 
	;WITH roles AS (
					SELECT
						 r.IdRol as IdRol 
						,r.Descripcion as Descripcion
						,r.ValorNumerico as ValorNumerico
						,r.BajaLogica as BajaLogica
						,r.UltimaActualizacion AS UltimaActualizacion
						,COUNT(1) OVER() AS TotalRows
					FROM  shared_owner.Roles r
					WHERE r.BajaLogica = 0  
					AND (@Descripcion is null OR r.Descripcion like + '%' + @Descripcion + '%')
					AND (@ValorNumerico is null OR r.ValorNumerico = @ValorNumerico)
					ORDER BY r.IdRol ASC 
					OFFSET @PageSize * (@PageNumber - 1) ROWS
					FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT roles.* FROM roles;
END