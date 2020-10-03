IF NOT EXISTS (SELECT 1 FROM shared_owner.MotivosBaja WHERE IdMotivoBaja=1)
BEGIN
	INSERT INTO shared_owner.MotivosBaja ([IdMotivoBaja],Descripcion,EventoTipo) 
	VALUES (1,'Error en carga de Contraparte', 'BAJA')
	PRINT 'Insert ID 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.MotivosBaja WHERE IdMotivoBaja=2)
BEGIN
	INSERT INTO shared_owner.MotivosBaja ([IdMotivoBaja],Descripcion,EventoTipo) 
	VALUES (2,'Error en carga de Producto', 'BAJA')
	PRINT 'Insert ID 2'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.MotivosBaja WHERE IdMotivoBaja=3)
BEGIN
	INSERT INTO shared_owner.MotivosBaja ([IdMotivoBaja],Descripcion,EventoTipo) 
	VALUES (3,'Error en carga de Vencimiento', 'BAJA')
	PRINT 'Insert ID 3'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.MotivosBaja WHERE IdMotivoBaja=4)
BEGIN
	INSERT INTO shared_owner.MotivosBaja ([IdMotivoBaja],Descripcion,EventoTipo) 
	VALUES (4,'Por disposición BCRA', 'BAJA')
	PRINT 'Insert ID 4'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.MotivosBaja WHERE IdMotivoBaja=5)
BEGIN
	INSERT INTO shared_owner.MotivosBaja ([IdMotivoBaja],Descripcion,EventoTipo) 
	VALUES (5,'Error carga cantidad-precio', 'BAJA')
	PRINT 'Insert ID 5'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.MotivosBaja WHERE IdMotivoBaja=6)
BEGIN
	INSERT INTO shared_owner.MotivosBaja ([IdMotivoBaja],Descripcion,EventoTipo) 
	VALUES (6,'Depuracion Batch', 'DEPURACION_BATCH')
	PRINT 'Insert ID 6'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.MotivosBaja WHERE IdMotivoBaja=7)
BEGIN
	INSERT INTO shared_owner.MotivosBaja ([IdMotivoBaja],Descripcion,EventoTipo) 
	VALUES (7,'Relanzar', 'RELANZAR')
	PRINT 'Insert ID 7'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.MotivosBaja WHERE IdMotivoBaja=8)
BEGIN
	INSERT INTO shared_owner.MotivosBaja ([IdMotivoBaja],Descripcion,EventoTipo) 
	VALUES (8,'Anular Confirmacion', 'ANULAR_CONFIRMACION')
	PRINT 'Insert ID 8'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.MotivosBaja WHERE IdMotivoBaja=9)
BEGIN
	INSERT INTO shared_owner.MotivosBaja ([IdMotivoBaja],Descripcion,EventoTipo) 
	VALUES (9, 'Cancelado por Sistema Externo', 'ANULAR_CONFIRMACION')
	PRINT 'Insert ID 9'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.MotivosBaja WHERE IdMotivoBaja=10)
BEGIN
	INSERT INTO shared_owner.MotivosBaja ([IdMotivoBaja],Descripcion,EventoTipo) 
	values (10,'Baja DMA','BAJA')
	PRINT 'Insert ID 10'
END