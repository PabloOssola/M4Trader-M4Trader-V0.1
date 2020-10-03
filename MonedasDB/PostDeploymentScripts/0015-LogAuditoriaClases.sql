IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Accion')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (1,'Accion', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Accion/Rol')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (2,'Accion/Rol', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 2'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Configuracion Seguridad')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (3,'Configuracion Seguridad', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 3'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Configuracion Sistema')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (4,'Configuracion Sistema', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 4'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Customizacion Usuario')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (5,'Customizacion Usuario', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 5'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Estado Sistema')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (6,'Estado Sistema', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 6'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Historico Password')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (7,'Historico Password', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 7'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Mensajes Literales')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (8,'Mensajes Literales', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 8'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Mercado')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (9,'Mercado', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 9'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Moneda')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (10,'Moneda', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 10'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Orden')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (11,'Orden', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 11'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Persona')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (12,'Persona', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 12'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Producto')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (13,'Producto', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 13'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Roles')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (14,'Roles', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 14'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Rol/Usuario')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (15,'Rol/Usuario', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 15'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Sesiones')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (16,'Sesiones', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 16'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Usuario')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (17,'Usuario', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 17'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Portfolios')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (18,'Portfolios', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 18'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'PortfoliosComposicion')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (19,'PortfoliosComposicion', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 19'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'PortfolioUsuario')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (20,'PortfolioUsuario', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 20'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'ProductosPorMercado')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (23,'ProductosPorMercado', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 23'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'OrdenOperacion')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (24,'OrdenOperacion', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 24'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'OrdenHistorico')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (25,'OrdenHistorico', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 25'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'ConfirmacionManual')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (26,'ConfirmacionManual', 'mae.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 25'
END

