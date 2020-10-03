IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposMoneda WHERE Descripcion = 'Moneda')
BEGIN
	INSERT INTO shared_owner.TiposMoneda (IdTipoMoneda, Descripcion) VALUES (1,'Moneda')
	PRINT 'Insert ID 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposMoneda WHERE Descripcion = 'Nominal')
BEGIN
	INSERT INTO shared_owner.TiposMoneda (IdTipoMoneda, Descripcion) VALUES (2,'Nominal')
	PRINT 'Insert ID 2'
END
