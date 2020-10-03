IF NOT EXISTS (SELECT 1 FROM shared_owner.SeguridadPermisos WHERE Descripcion = 'CONSULTA')
BEGIN
	INSERT INTO shared_owner.SeguridadPermisos (IdPermiso, Descripcion) VALUES (1, 'CONSULTA')
	PRINT 'Insert ID 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.SeguridadPermisos WHERE Descripcion = 'SALIDAS')
BEGIN
	INSERT INTO shared_owner.SeguridadPermisos (IdPermiso, Descripcion) VALUES (2, 'SALIDAS')
	PRINT 'Insert ID 2'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.SeguridadPermisos WHERE Descripcion = 'MODIFICACION')
BEGIN
	INSERT INTO shared_owner.SeguridadPermisos (IdPermiso, Descripcion) VALUES (4, 'MODIFICACION')
	PRINT 'Insert ID 3'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.SeguridadPermisos WHERE Descripcion = 'BAJA')
BEGIN
	INSERT INTO shared_owner.SeguridadPermisos (IdPermiso, Descripcion) VALUES (8, 'BAJA')
	PRINT 'Insert ID 4'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.SeguridadPermisos WHERE Descripcion = 'ALTA')
BEGIN
	INSERT INTO shared_owner.SeguridadPermisos (IdPermiso, Descripcion) VALUES (16, 'ALTA')
	PRINT 'Insert ID 5'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.SeguridadPermisos WHERE Descripcion = 'SUPERVISION')
BEGIN
	INSERT INTO shared_owner.SeguridadPermisos (IdPermiso, Descripcion) VALUES (32, 'SUPERVISION')
	PRINT 'Insert ID 6'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.SeguridadPermisos WHERE Descripcion = 'IMPORTACION')
BEGIN
	INSERT INTO shared_owner.SeguridadPermisos (IdPermiso, Descripcion) VALUES (64, 'IMPORTACION')
	PRINT 'Insert ID 7'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.SeguridadPermisos WHERE Descripcion = 'APROBACION_AUTOMATICA')
BEGIN
	INSERT INTO shared_owner.SeguridadPermisos (IdPermiso, Descripcion) VALUES (128, 'APROBACION_AUTOMATICA')
	PRINT 'Insert ID 8'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.SeguridadPermisos WHERE Descripcion = 'EJECUCION')
BEGIN
	INSERT INTO shared_owner.SeguridadPermisos (IdPermiso, Descripcion) VALUES (256, 'EJECUCION')
	PRINT 'Insert ID 9'
END
