DECLARE @IdTipoPersona TINYINT

IF NOT EXISTS (SELECT 1 FROM shared_owner.Parties WHERE [Name] = 'MAE S.A.')
BEGIN
	SELECT @IdTipoPersona = IdTipoPersona FROM shared_owner.TiposPersona WHERE Descripcion = 'LIQUIDADOR'
	INSERT INTO shared_owner.Parties (IdParty, MarketCustomerNumber, [Name], PartyType, AgentCode) VALUES (1, '001', 'MAE S.A.', @IdTipoPersona, 'URU2')
	PRINT 'Insert MAE S.A.'
END


IF NOT EXISTS (SELECT 1 FROM shared_owner.Parties WHERE [Name] = 'Anónimo')
BEGIN
	SELECT @IdTipoPersona = IdTipoPersona FROM shared_owner.TiposPersona WHERE Descripcion = 'ANONIMO'
	IF NOT EXISTS (SELECT 1 FROM shared_owner.Parties WHERE IdParty = 8)
	BEGIN
		INSERT INTO shared_owner.Parties (IdParty, MarketCustomerNumber, [Name], PartyType) VALUES (8, '000', 'Anónimo', @IdTipoPersona)
		PRINT 'Insert Anónimo'
	END
	ELSE
	BEGIN
		INSERT INTO shared_owner.Parties (MarketCustomerNumber, [Name], PartyType) VALUES ('000', 'Anónimo', @IdTipoPersona)
		PRINT 'Insert ANONIMO'
	END
END

IF NOT EXISTS(SELECT 1 FROM shared_owner.Parties WHERE Name = 'Adm Facturas')
BEGIN
	INSERT INTO shared_owner.Parties (DocumentNumber, Name, MarketCustomerNumber, PartyType,IdLegalPersonality,TaxIdentificationNumber)
	VALUES('20304501','Adm Facturas','001',8,1,'20203045010')
	PRINT 'Party Adm Facturas insertado'
End
ELSE
BEGIN
	PRINT 'Ya existe party Adm Facturas'
END


--INSERTAR SEGUN EL AMBIENTE MAE_DMA o Rofex_Arpenta_Byma
PRINT 'INSERTAR SEGUN EL AMBIENTE MAE_DMA o Rofex_Arpenta_Byma'