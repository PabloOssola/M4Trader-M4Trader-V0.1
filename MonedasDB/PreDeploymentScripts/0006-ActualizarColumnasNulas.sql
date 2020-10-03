UPDATE orden_owner.PortfoliosComposicion SET Orden = 1 WHERE ORDEN IS NULL

IF (1 > (SELECT COUNT(1) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'shared_owner' AND TABLE_NAME='Monedas' AND COLUMN_NAME = 'CodigoISO'))
BEGIN
	ALTER TABLE shared_owner.Monedas ADD CodigoISO VARCHAR (4) NULL
	EXEC ('UPDATE shared_owner.Monedas SET CodigoISO = ''ARS'' WHERE Codigo = ''$''')
	EXEC ('UPDATE shared_owner.Monedas SET CodigoISO = ''USD'' WHERE Codigo = ''D''')
	EXEC ('UPDATE shared_owner.Monedas SET CodigoISO = ''EUR'' WHERE Codigo = ''E''')
END

ALTER TABLE orden_owner.Productos ALTER COLUMN Codigo varchar(32) not null
