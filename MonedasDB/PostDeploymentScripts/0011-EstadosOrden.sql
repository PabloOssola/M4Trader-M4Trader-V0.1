IF NOT EXISTS (SELECT 1 FROM [orden_owner].EstadosOrden WHERE IdEstadoOrden=1)
BEGIN
	INSERT INTO [orden_owner].EstadosOrden (IdEstadoOrden,Descripcion) 
	VALUES (1,'Ingresada')
	PRINT 'Insert ID 1'
END

IF NOT EXISTS (SELECT 1 FROM [orden_owner].EstadosOrden WHERE IdEstadoOrden=2)
BEGIN
	INSERT INTO [orden_owner].EstadosOrden (IdEstadoOrden,Descripcion)
	VALUES (2,'Cancelada')
	PRINT 'Insert ID 2'
END
IF NOT EXISTS (SELECT 1 FROM [orden_owner].EstadosOrden WHERE IdEstadoOrden=3)
BEGIN
	INSERT INTO [orden_owner].EstadosOrden (IdEstadoOrden,Descripcion)
	VALUES (3,'Expirada')
	PRINT 'Insert ID 3'
END

IF NOT EXISTS (SELECT 1 FROM [orden_owner].EstadosOrden WHERE IdEstadoOrden=4)
BEGIN
	INSERT INTO [orden_owner].EstadosOrden (IdEstadoOrden,Descripcion)
	VALUES (4,'Confirmada')
	PRINT 'Insert ID 4'
END

IF NOT EXISTS (SELECT 1 FROM [orden_owner].EstadosOrden WHERE IdEstadoOrden=5)
BEGIN
	INSERT INTO [orden_owner].EstadosOrden (IdEstadoOrden,Descripcion)
	VALUES (5,'Aplicada')
	PRINT 'Insert ID 5'
END

IF NOT EXISTS (SELECT 1 FROM [orden_owner].EstadosOrden WHERE IdEstadoOrden=6)
BEGIN
	INSERT INTO [orden_owner].EstadosOrden (IdEstadoOrden,Descripcion)
	VALUES (6,'Aplicada Parcial')
	PRINT 'Insert ID 6'
END

IF NOT EXISTS (SELECT 1 FROM [orden_owner].EstadosOrden WHERE IdEstadoOrden=7)
BEGIN
	INSERT INTO [orden_owner].EstadosOrden (IdEstadoOrden,Descripcion)
	VALUES (7,'Rechazo Envio Mercado')
	PRINT 'Insert ID 7'
END

IF NOT EXISTS (SELECT 1 FROM [orden_owner].EstadosOrden WHERE IdEstadoOrden=8)
BEGIN
	INSERT INTO [orden_owner].EstadosOrden (IdEstadoOrden,Descripcion)
	VALUES (8,'En Mercado')
	PRINT 'Insert ID 8'
END

IF NOT EXISTS (SELECT 1 FROM [orden_owner].EstadosOrden WHERE IdEstadoOrden=9)
BEGIN
	INSERT INTO [orden_owner].EstadosOrden (IdEstadoOrden,Descripcion)
	VALUES (9,'Bloqueada')
	PRINT 'Insert ID 9'
END

IF NOT EXISTS (SELECT 1 FROM [orden_owner].EstadosOrden WHERE IdEstadoOrden=10)
BEGIN
	INSERT INTO [orden_owner].EstadosOrden (IdEstadoOrden,Descripcion)
	VALUES (10,'Rechazada por Cierre')
	PRINT 'Insert ID 10'
END

