CREATE PROCEDURE orden_owner.QRY_SCRN_USUARIOSWEB_FILTERS_BUNDLE
AS
BEGIN 
    SET NOCOUNT ON;

 SELECT 0 as Orden, 'IdPartyType' as NombreCampo    
 UNION SELECT 1 as Orden, 'IdLegalPersonality' as NombreCampo    
 Order by Orden    
 
 --0
 SELECT Descripcion as TipoPersonaDescripcion, IdTipoPersona as IdPartyType     
 FROM shared_owner.TiposPersona    
 
 --1
 SELECT Descripcion as PersoneriaJuridicaDescripcion, IdPersoneriaJuridica as IdLegalPersonality FROM shared_owner.PersoneriaJuridica    

 ----2

END
