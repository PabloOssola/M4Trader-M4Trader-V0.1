CREATE  PROCEDURE orden_owner.QRY_SCRN_PERSONAS_FILTERS_BUNDLE
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
 --SELECT   
	-- EmpresaDescripcion = NombrePersona,   
	-- IdEmpresa = IdPersona  
	-- FROM shared_owner.Parties  P
	-- JOIN shared_owner.TiposPersona T on T.IdTipoPersona = P.PartyType
	-- where T.Descripcion = 'EMPRESA'
  

END
GO

