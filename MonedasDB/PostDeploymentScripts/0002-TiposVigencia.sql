IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposVigencia WHERE IdTipoVigencia=1)
BEGIN
	INSERT INTO shared_owner.TiposVigencia (IdTipoVigencia,Descripcion) 
	VALUES (1,'No Aplica')
	PRINT 'Insert ID 1'
END

IF NOT EXISTS (SELECT 2 FROM shared_owner.TiposVigencia WHERE IdTipoVigencia=2)
BEGIN
	INSERT INTO shared_owner.TiposVigencia (IdTipoVigencia,Descripcion) 
	VALUES (2,'Días Hábiles')
	PRINT 'Insert ID 2'
END

IF NOT EXISTS (SELECT 3 FROM shared_owner.TiposVigencia WHERE IdTipoVigencia=3)
BEGIN
	INSERT INTO shared_owner.TiposVigencia (IdTipoVigencia,Descripcion) 
	VALUES (3,'Horas')
	PRINT 'Insert ID 3'
END

