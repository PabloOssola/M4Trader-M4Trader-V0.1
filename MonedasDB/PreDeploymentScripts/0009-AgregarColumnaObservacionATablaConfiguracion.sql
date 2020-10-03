IF (1 > (SELECT COUNT(1) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'fix_owner' AND TABLE_NAME='ConfiguracionInterfaces' AND COLUMN_NAME = 'Observacion'))
BEGIN
	ALTER TABLE fix_owner.ConfiguracionInterfaces ADD Observacion VARCHAR(100) NULL
	PRINT 'fix_owner.ConfiguracionInterfaces.Observacion'
END
