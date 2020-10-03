IF NOT EXISTS(SELECT 1 FROM orden_owner.TiposProducto WHERE Descripcion = 'Totales')
BEGIN
	INSERT INTO orden_owner.TiposProducto (Descripcion)
	VALUES('Totales')
	PRINT 'Totales insertado'
END

IF NOT EXISTS(SELECT 1 FROM orden_owner.TiposProducto WHERE Descripcion = 'Monedas')
BEGIN
	INSERT INTO orden_owner.TiposProducto (Descripcion)
	VALUES('Monedas')
	PRINT 'Monedas insertado'
END

IF NOT EXISTS(SELECT 1 FROM orden_owner.TiposProducto WHERE Descripcion = 'Bonos')
BEGIN
	INSERT INTO orden_owner.TiposProducto (Descripcion)
	VALUES('Bonos')
	PRINT 'Bonos insertado'
END

IF NOT EXISTS(SELECT 1 FROM orden_owner.TiposProducto WHERE Descripcion = 'Acciones')
BEGIN
	INSERT INTO orden_owner.TiposProducto (Descripcion)
	VALUES('Acciones')
	PRINT 'Acciones insertado'
END

IF NOT EXISTS(SELECT 1 FROM orden_owner.TiposProducto WHERE Descripcion = 'Opciones')
BEGIN
	INSERT INTO orden_owner.TiposProducto (Descripcion)
	VALUES('Opciones')
	PRINT 'Opciones insertado'
END

IF NOT EXISTS(SELECT 1 FROM orden_owner.TiposProducto WHERE Descripcion = 'Futuros')
BEGIN
	INSERT INTO orden_owner.TiposProducto (Descripcion)
	VALUES('Futuros')
	PRINT 'Futuros insertado'
END

IF NOT EXISTS(SELECT 1 FROM orden_owner.TiposProducto WHERE Descripcion = 'Facturas')
BEGIN
	INSERT INTO orden_owner.TiposProducto (Descripcion)
	VALUES('Facturas')
	PRINT 'Facturas insertado'
END