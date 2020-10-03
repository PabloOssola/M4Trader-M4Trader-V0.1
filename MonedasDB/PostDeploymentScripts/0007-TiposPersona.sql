--IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'CARTERA PROPIA')
--BEGIN
--	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES (1, 'CARTERA PROPIA')
--	PRINT 'Insert ID 1'
--END

--IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'AGENTE')
--BEGIN
--	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES (2, 'AGENTE')
--	PRINT 'Insert ID 2'
--END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'CLIENTE')
BEGIN
	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES (3, 'CLIENTE')
	PRINT 'Insert ID 3'
END

--IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'DEPOSITARIA')
--BEGIN
--	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES (4, 'DEPOSITARIA')
--	PRINT 'Insert ID 4'
--END

--IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'CUSTODIO')
--BEGIN
--	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES (5, 'CUSTODIO')
--	PRINT 'Insert ID 5'
--END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'LIQUIDADOR')
BEGIN
	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES (6, 'LIQUIDADOR')
	PRINT 'Insert ID 6'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'NEGOCIADOR')
BEGIN
	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES (7, 'NEGOCIADOR')
	PRINT 'Insert ID 7'
END

IF NOT EXISTS(SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'ADMFCE')
BEGIN
	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES(8,'ADMFCE')
	PRINT 'Insert ID 8'
END

IF NOT EXISTS(SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'ADMUSUARIOS')
BEGIN
	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES(9,'ADMUSUARIOS')
	PRINT 'Insert ID 9'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'ANONIMO')
BEGIN
	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES (0, 'ANONIMO')
	PRINT 'Insert ID 0'
END


/********** PERSONERIA JURIDICA **************/
IF NOT EXISTS (SELECT 1 FROM shared_owner.PersoneriaJuridica WHERE Descripcion = 'Persona Fisica')
BEGIN
	INSERT INTO shared_owner.PersoneriaJuridica (IdPersoneriaJuridica, Descripcion) VALUES (1, 'Persona Fisica')
	PRINT 'Insert ID PJ 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.PersoneriaJuridica WHERE Descripcion = 'Persona Juridica')
BEGIN
	INSERT INTO shared_owner.PersoneriaJuridica (IdPersoneriaJuridica, Descripcion) VALUES (2, 'Persona Juridica')
	PRINT 'Insert ID PJ 2'
END
