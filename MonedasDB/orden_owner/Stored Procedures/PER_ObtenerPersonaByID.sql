CREATE PROCEDURE [orden_owner].[PER_ObtenerPersonaByID]
  @idPersona int
AS        
BEGIN   
	SELECT 
	p.IdParty AS IdPersona,
	p.DocumentNumber AS NroDocumento,
	p.Name AS NombrePersona,
	p.MarketCustomerNumber AS NroCliente,
	p.PartyType AS TipoPersona,
	p.IdLegalPersonality AS IdPersoneriaJuridica, 
	p.TaxIdentificationNumber AS NroIdentificacionTributaria,
	p.Phone AS Telefono
	FROM shared_owner.Parties p
	WHERE p.IdParty = @idPersona

END
