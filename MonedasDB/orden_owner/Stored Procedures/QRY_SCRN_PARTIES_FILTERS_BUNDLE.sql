CREATE PROCEDURE [orden_owner].[QRY_SCRN_PARTIES_FILTERS_BUNDLE]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT			0 as Orden, 'Party' as NombreCampo
	Order by Orden
 
	select 'Todos'as NombrePersona, 0  as IdPersona
	union
	SELECT  p.Name as NombrePersona, p.IdParty as IdPersona FROM shared_owner.Parties p
	
END