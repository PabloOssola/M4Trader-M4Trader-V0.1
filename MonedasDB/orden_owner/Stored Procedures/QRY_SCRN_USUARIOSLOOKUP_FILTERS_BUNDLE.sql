CREATE PROCEDURE [orden_owner].[QRY_SCRN_USUARIOSLOOKUP_FILTERS_BUNDLE]
@PageNumber int,
@PageSize int, 
@query varchar(10)=NULL, 
@NombreUsuario varchar(200)=NULL, 
@IdUsuario int=NULL
WITH RECOMPILE
AS  
BEGIN  
 
;WITH pg AS (
				SELECT  
				u.IdUsuario AS IdUsuario,
				u.Nombre AS NombreUsuario,
				COUNT(1) OVER() AS TotalRows
				FROM shared_owner.Usuarios u 
				INNER JOIN shared_owner.Parties as p on u.IdPersona = p.IdParty
				INNER JOIN shared_owner.TiposPersona as tp on p.PartyType = tp.IdTipoPersona
				WHERE (@query is null or u.Nombre like '%' + @query +'%')
				and (@NombreUsuario is null or u.Nombre like '%' + @NombreUsuario +'%')
				and (@IdUsuario is null or u.IdUsuario = @IdUsuario)
				--and tp.IdTipoPersona = 2
				AND u.BajaLogica = 0
				ORDER BY u.IdUsuario DESC
				OFFSET @PageSize * (@PageNumber - 1) ROWS
				FETCH NEXT @PageSize ROWS ONLY
				)
	SELECT pg.* FROM pg ORDER BY pg.IdUsuario desc

END
