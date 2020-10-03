IF NOT EXISTS (SELECT 1 FROM [orden_owner].TiposOrden WHERE IdTipoOrden=1)
BEGIN
	INSERT INTO [orden_owner].TiposOrden (IdTipoOrden,Codigo,Descripcion) 
	VALUES (1,'0','Day')
	PRINT 'Insert ID 1'
END

IF NOT EXISTS (SELECT 2 FROM [orden_owner].TiposOrden WHERE IdTipoOrden=2)
BEGIN
	INSERT INTO [orden_owner].TiposOrden (IdTipoOrden,Codigo,Descripcion) 
	VALUES (2,'3','IOC')
	PRINT 'Insert ID 2'
END

IF NOT EXISTS (SELECT 3 FROM [orden_owner].TiposOrden WHERE IdTipoOrden=3)
BEGIN
	INSERT INTO [orden_owner].TiposOrden (IdTipoOrden,Codigo,Descripcion) 
	VALUES (3,'6','GTD')
	PRINT 'Insert ID 3'
END
IF NOT EXISTS (SELECT 3 FROM [orden_owner].TiposOrden WHERE IdTipoOrden=4)
BEGIN
	INSERT INTO [orden_owner].TiposOrden (IdTipoOrden,Codigo,Descripcion) 
	VALUES (4,'1','GTC')
	PRINT 'Insert ID 4'
END

