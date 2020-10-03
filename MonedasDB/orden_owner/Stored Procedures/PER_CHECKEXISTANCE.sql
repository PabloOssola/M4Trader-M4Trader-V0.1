CREATE procedure [orden_owner].[PER_CHECKEXISTANCE]
	@DocumentNumber	VARCHAR(50)
	AS
	BEGIN
		SELECT Name, Username, Phone, IdLegalPersonality, TaxIdentificationNumber, Email
		from shared_owner.Parties p
		left join shared_owner.Usuarios u on u.IdPersona = p.IdParty
		where p.documentNumber = @DocumentNumber
END
GO