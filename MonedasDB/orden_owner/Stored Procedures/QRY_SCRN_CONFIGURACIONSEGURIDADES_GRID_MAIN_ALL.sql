CREATE PROCEDURE [orden_owner].[QRY_SCRN_CONFIGURACIONSEGURIDADES_GRID_MAIN_ALL]
    @PageNumber bigint=NULL, 
    @PageSize bigint=0
AS
BEGIN 
	;WITH confSeguridad AS (
		select 
			IdConfiguracionSeguridad, 
			TimeOutInicialSesion, 
			TimeOutExtensionSesion, 
			CantidadIntentosMaximo, 
			DiasCambioPassword, 
			MaximoDiasInactividad, 
			CantidadPasswordsHistoricas, 
			ConsideraMinimoLargoPassword, 
			CantidadMinimoLargoPassword, 
			ConsideraCantidadCaracteres, 
			CantidadAlfabeticosPassword, 
			CantidadNumericosPassword,
			ConsideraMaximaCantCaracteresConsecutivos, 
			CantidadMaximaCaracteresConsecutivos, 
			CantidadMayusculasPassword, 
			CantidadMinusculasPassword, 
			CantidadSimbolosPassword,
			DobleAutenticacion, 
			COUNT(1) OVER() AS TotalRows
		from shared_owner.ConfiguracionSeguridad
	)
				
	SELECT * FROM confSeguridad;
END