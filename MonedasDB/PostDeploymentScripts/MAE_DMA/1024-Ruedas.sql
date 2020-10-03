IF NOT EXISTS (SELECT 1 FROM shared_owner.RuedasBySecurityList WHERE Codigo = 'CPC1')
BEGIN
	INSERT INTO shared_owner.RuedasBySecurityList (Codigo, Descripcion, IdMercado, Habilitada, PedirSecurityList) VALUES ('CPC1', 'CPC1', 1, 1, 1)
	PRINT 'Insert CPC1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RuedasBySecurityList WHERE Codigo = 'ONTI')
BEGIN
	INSERT INTO shared_owner.RuedasBySecurityList (Codigo, Descripcion, IdMercado, Habilitada, PedirSecurityList) VALUES ('ONTI', 'ONTI', 1, 0, 1)
	PRINT 'Insert ONTI'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RuedasBySecurityList WHERE Codigo = 'LUCH')
BEGIN
	INSERT INTO shared_owner.RuedasBySecurityList (Codigo, Descripcion, IdMercado, Habilitada, PedirSecurityList) VALUES ('LUCH', 'LUCH', 1, 1, 1)
	PRINT 'Insert LUCH'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RuedasBySecurityList WHERE Codigo = 'TRD')
BEGIN
	INSERT INTO shared_owner.RuedasBySecurityList (Codigo, Descripcion, IdMercado, Habilitada, PedirSecurityList) VALUES ('TRD', 'TRD', 1, 0, 0)
	PRINT 'Insert TRD'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RuedasBySecurityList WHERE Codigo = 'INDX')
BEGIN
	INSERT INTO shared_owner.RuedasBySecurityList (Codigo, Descripcion, IdMercado, Habilitada, PedirSecurityList) VALUES ('INDX', 'INDX', 1, 0, 0)
	PRINT 'Insert INDX'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RuedasBySecurityList WHERE Codigo = 'LICI')
BEGIN
	INSERT INTO shared_owner.RuedasBySecurityList (Codigo, Descripcion, IdMercado, Habilitada, PedirSecurityList) VALUES ('LICI', 'LICI', 1, 0, 0)
	PRINT 'Insert LICI'
END