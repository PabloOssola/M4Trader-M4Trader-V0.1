CREATE PROCEDURE [orden_owner].[QRY_SCRN_LOGAUDITORIA_FILTERS_BUNDLE]
AS
BEGIN 
    SET NOCOUNT ON;
    
	SELECT 0 as Orden, 'IdLogAuditoriaClase' as NombreCampo
	UNION SELECT 1 as Orden, 'IdTipoEvento' as NombreCampo;

	SELECT '-- Todos --' as NombreEntidad, 0 as 'IdLogAuditoriaClase'
	UNION SELECT NombreEntidad, IdLogAuditoriaClase as 'IdLogAuditoriaClase'
	from shared_owner.LogAuditoriaClases;

	SELECT '-- Todos --' as TipoEvento, -1 as 'IdTipoEvento'
	UNION 
	SELECT 'Alta' as TipoEvento, 0 as 'IdTipoEvento'
	UNION SELECT 'Eliminación' as TipoEvento, 1 as 'IdTipoEvento'
	UNION SELECT 'Modificación' as TipoEvento, 2 as 'IdTipoEvento'
END
