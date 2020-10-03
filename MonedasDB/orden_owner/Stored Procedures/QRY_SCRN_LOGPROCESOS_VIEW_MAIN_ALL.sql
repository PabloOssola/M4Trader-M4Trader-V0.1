CREATE PROCEDURE [orden_owner].[QRY_SCRN_LOGPROCESOS_VIEW_MAIN_ALL]    
@IdLogProceso BIGINT = null 
AS
BEGIN  
	
	SELECT 
	   LP.[IdLogProceso]
      ,LP.[IdUsuario]
      ,LP.[Fecha]
      ,LP.[Descripcion]
      ,LP.[Resultado]
      ,LP.[RequestId]
      ,LP.[IdLogCodigoAccion]
	  ,LCA.[Descripcion] AS LogCodigoAccion
  FROM [orden_owner].[LogProcesos] LP LEFT JOIN shared_owner.LogCodigoAccion LCA ON LP.IdLogCodigoAccion = LCA.IdLogCodigoAccion
    WHERE (NOT @IdLogProceso IS NULL AND LP.IdLogProceso = @IdLogProceso) 
END