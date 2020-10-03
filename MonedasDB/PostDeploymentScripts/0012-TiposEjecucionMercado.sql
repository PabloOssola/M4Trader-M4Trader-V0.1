IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposEjecucionMercado WHERE IdTipoEjecucionMercado=1)
BEGIN
	INSERT INTO shared_owner.TiposEjecucionMercado (IdTipoEjecucionMercado,Codigo,Descripcion) 
	VALUES (1,'1','Pendiente')
	PRINT 'Insert ID 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposEjecucionMercado WHERE IdTipoEjecucionMercado=2)
BEGIN
	INSERT INTO shared_owner.TiposEjecucionMercado (IdTipoEjecucionMercado,Codigo,Descripcion) 
	VALUES (2,'2','Recibido')
	PRINT 'Insert ID 2'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposEjecucionMercado WHERE IdTipoEjecucionMercado=3)
BEGIN
	INSERT INTO shared_owner.TiposEjecucionMercado (IdTipoEjecucionMercado,Codigo,Descripcion) 
	VALUES (3,'3','Rechazada')
	PRINT 'Insert ID 3'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposEjecucionMercado WHERE IdTipoEjecucionMercado=4)
BEGIN
	INSERT INTO shared_owner.TiposEjecucionMercado (IdTipoEjecucionMercado,Codigo,Descripcion) 
	VALUES (4,'4','Cancelada')
	PRINT 'Insert ID 4'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposEjecucionMercado WHERE IdTipoEjecucionMercado=5)
BEGIN
	INSERT INTO shared_owner.TiposEjecucionMercado (IdTipoEjecucionMercado,Codigo,Descripcion) 
	VALUES (5,'5','Expirada')
	PRINT 'Insert ID 5'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposEjecucionMercado WHERE IdTipoEjecucionMercado=6)
BEGIN
	INSERT INTO shared_owner.TiposEjecucionMercado (IdTipoEjecucionMercado,Codigo,Descripcion) 
	VALUES (6,'6','Pendiente Modificación')
	PRINT 'Insert ID 6'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposEjecucionMercado WHERE IdTipoEjecucionMercado=7)
BEGIN
	INSERT INTO shared_owner.TiposEjecucionMercado (IdTipoEjecucionMercado,Codigo,Descripcion) 
	VALUES (7,'7','Modificada')
	PRINT 'Insert ID 7'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposEjecucionMercado WHERE IdTipoEjecucionMercado=8)
BEGIN
	INSERT INTO shared_owner.TiposEjecucionMercado (IdTipoEjecucionMercado,Codigo,Descripcion) 
	VALUES (8,'8','Concertada Parcial')
	PRINT 'Insert ID 8'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposEjecucionMercado WHERE IdTipoEjecucionMercado=9)
BEGIN
	INSERT INTO shared_owner.TiposEjecucionMercado (IdTipoEjecucionMercado,Codigo,Descripcion) 
	VALUES (9,'9','Operación')
	PRINT 'Insert ID 9'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposEjecucionMercado WHERE IdTipoEjecucionMercado=10)
BEGIN
	INSERT INTO shared_owner.TiposEjecucionMercado (IdTipoEjecucionMercado,Codigo,Descripcion) 
	VALUES (10,'10','Pendiente Cancelación')
	PRINT 'Insert ID 10'
END

