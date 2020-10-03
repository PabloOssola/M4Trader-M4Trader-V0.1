IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Ingreso al Sistema')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (1, 'Ingreso al Sistema', 1)
	PRINT 'Insert ID 1'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 1 WHERE Descripcion = 'Ingreso al Sistema'
	PRINT 'UPDATE ID 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Consultas Generales')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (2, 'Consultas Generales', 2)
	PRINT 'Insert ID 2'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 2 WHERE Descripcion = 'Consultas Generales'
	PRINT 'UPDATE ID 2'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Administrador')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (3, 'Administrador', 3)
	PRINT 'Insert ID 3'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 3 WHERE Descripcion = 'Administrador'
	PRINT 'UPDATE ID 3'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Cliente')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (4, 'Cliente', 4)
	PRINT 'Insert ID 4'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 4 WHERE Descripcion = 'Cliente'
	PRINT 'UPDATE ID 4'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Ordenes')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (5, 'Ordenes', 5)
	PRINT 'Insert ID 5'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 5 WHERE Descripcion = 'Ordenes'
	PRINT 'UPDATE ID 5'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Ingreso al Sistema MOBILE')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (6, 'Ingreso al Sistema MOBILE', 6)
	PRINT 'Insert ID 6'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 6 WHERE Descripcion = 'Ingreso al Sistema MOBILE'
	PRINT 'UPDATE ID 6'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Ingreso al Sistema API')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (7, 'Ingreso al Sistema API', 7)
	PRINT 'Insert ID 7'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 7 WHERE Descripcion = 'Ingreso al Sistema API'
	PRINT 'UPDATE ID 7'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Anónimo')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (8, 'Anónimo', 8)
	PRINT 'Insert ID 8'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 8 WHERE Descripcion = 'Anónimo'
	PRINT 'UPDATE ID 8'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Administración Usuarios')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (9, 'Administración Usuarios', 9)
	PRINT 'Insert ID 9'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 9 WHERE Descripcion = 'Administración Usuarios'
	PRINT 'UPDATE ID 9'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'DMA')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) VALUES (10, 'DMA', 10)
	PRINT 'Insert ID 10'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 10 WHERE Descripcion = 'DMA'
	PRINT 'UPDATE ID 10'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'COMPLEMENTODMA')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) VALUES (11, 'COMPLEMENTODMA', 11)
	PRINT 'Insert ID 11'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 11 WHERE Descripcion = 'COMPLEMENTODMA'
	PRINT 'UPDATE ID 11'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Administrador Facturas')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) VALUES (12, 'Administrador Facturas', 12)
	PRINT 'Insert ID 12'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 12 WHERE Descripcion = 'Administrador Facturas'
	PRINT 'UPDATE ID 12'
END