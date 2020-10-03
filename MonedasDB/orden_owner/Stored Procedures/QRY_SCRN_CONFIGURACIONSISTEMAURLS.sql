CREATE PROCEDURE [orden_owner].[QRY_SCRN_CONFIGURACIONSISTEMAURLS]   
    @PageNumber int=NULL, 
    @PageSize int=0
AS
BEGIN 
       ;WITH pg AS (
             SELECT urls.IdConfiguracionSistemaUrls
			 ,urls.Url AS Url
			 ,urls.TipoUrl AS TipoUrl
			 ,urls.Usuario
			 ,urls.Password
			 ,urls.Parametros
             ,COUNT(1) OVER() AS TotalRows
             FROM  orden_owner.ConfiguracionSistemaUrls urls
			 INNER JOIN shared_owner.ConfiguracionSistema cs ON (cs.IdConfiguracionSistema = urls.IdConfiguracionSistema)
			 )
                           
       SELECT pg.* FROM pg;
END
GO

