DECLARE @IdTipoPersona TINYINT

IF NOT EXISTS (SELECT 1 FROM shared_owner.Parties WHERE [Name] = 'HSBC')
BEGIN
	SELECT @IdTipoPersona = IdTipoPersona FROM shared_owner.TiposPersona WHERE Descripcion = 'NEGOCIADOR'
	INSERT INTO shared_owner.Parties (MarketCustomerNumber, [Name], PartyType, TaxIdentificationNumber, AgentCode) VALUES ('004', 'HSBC', @IdTipoPersona, '33-53718600-9', '167')
	PRINT 'Insert HSBC'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Parties WHERE [Name] = 'BBVA')
BEGIN
	SELECT @IdTipoPersona = IdTipoPersona FROM shared_owner.TiposPersona WHERE Descripcion = 'NEGOCIADOR'
	INSERT INTO shared_owner.Parties (MarketCustomerNumber, [Name], PartyType, TaxIdentificationNumber, AgentCode) VALUES ('105', 'BBVA', @IdTipoPersona, '30-50000319-3', '42')
	PRINT 'Insert BBVA'
END