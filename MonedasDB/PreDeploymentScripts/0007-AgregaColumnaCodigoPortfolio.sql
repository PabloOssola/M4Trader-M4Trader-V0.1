IF (1 > (SELECT COUNT(1) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'orden_owner' AND TABLE_NAME='Portfolios' AND COLUMN_NAME = 'Codigo'))
BEGIN
	ALTER TABLE orden_owner.Portfolios ADD Codigo VARCHAR(5) NULL
	EXEC ('UPDATE orden_owner.Portfolios SET Codigo = SUBSTRING(Nombre, 0, 5)')
	ALTER TABLE orden_owner.Portfolios ALTER COLUMN Codigo VARCHAR(5) NOT NULL
END
