IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Usuarios')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (1, 'Usuarios', 31)
	PRINT 'Insert ID 1'

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Estado del sistema')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (2, 'Estado del sistema', 257)
	PRINT 'Insert ID 2'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Cambio Clave')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (3, 'Cambio Clave', 257)
	PRINT 'Insert ID 3'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'GetPermisosAcciones')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (4, 'GetPermisosAcciones', 1)
	PRINT 'Insert ID 4'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Ordenar Pantallas')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (5, 'Ordenar Pantallas', 256)
	PRINT 'Insert ID 5'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Ordenes')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (6, 'Ordenes', 1)
	PRINT 'Insert ID 6'
END

END
IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Abrir Sistema')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (7, 'Abrir Sistema', 256)
	PRINT 'Insert ID 7'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Anular Cierre Sistema')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (8, 'Anular Cierre Sistema', 256)
	PRINT 'Insert ID 8'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Rol')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (9, 'Rol', 31)
	PRINT 'Insert ID 9'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Monedas')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (10, 'Monedas', 31)
	PRINT 'Insert ID 10'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Mercados')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (11, 'Mercados', 31)
	PRINT 'Insert ID 11'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Login')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (12, 'Login', 1)
	PRINT 'Insert ID 12'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Productos')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (13, 'Productos', 255)
	PRINT 'Insert ID 13'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Ejecutar Procesos Encadenados')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (14, 'Ejecutar Procesos Encadenados', 256)
	PRINT 'Insert ID 14'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Configuracion Sistema')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (15, 'Configuracion Sistema', 255)
	PRINT 'Insert ID 15'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Configuracion Seguridad')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (16, 'Configuracion Seguridad', 31)
	PRINT 'Insert ID 16'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Accion Rol')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (17, 'Accion Rol', 31)
	PRINT 'Insert ID 17'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Consultas Generales')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (18, 'Consultas Generales', 1)
	PRINT 'Insert ID 18'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Consultas Auditoria')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (19, 'Consultas Auditoria', 1)
	PRINT 'Insert ID 19'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Administrador Usuario')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (20, 'Administrador Usuario', 31)
	PRINT 'Insert ID 20'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Administracion de Sesiones')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (21, 'Administracion de Sesiones', 15)
	PRINT 'Insert ID 21'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Personas')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (22, 'Personas', 255)
	PRINT 'Insert ID 22'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Accion')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (23, 'Accion', 31)
	PRINT 'Insert ID 23'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'MarketWatch')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (24, 'MarketWatch', 1)
	PRINT 'Insert ID 24'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Portfolio')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (25, 'Portfolio', 29)
	PRINT 'Insert ID 25'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'PortfoliosComposicion')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (26, 'PortfoliosComposicion', 29)
	PRINT 'Insert ID 26'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'PortfolioUsuario')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (27, 'PortfolioUsuario', 285)
	PRINT 'Insert ID 27'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'AppContext')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (29, 'AppContext', 1)
	PRINT 'Insert ID 29'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Menu')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (30, 'Menu', 1)
	PRINT 'Insert ID 30'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'ProductosPorMercado')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (31, 'ProductosPorMercado', 1)
	PRINT 'Insert ID 31'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Autenticar Api')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (32, 'Autenticar Api', 1)
	PRINT 'Insert ID 32'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Autenticar Mobile')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (33, 'Autenticar Mobile', 1)
	PRINT 'Insert ID 33'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'CierreMercadoInterno')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (34, 'CierreMercadoInterno', 1)
	PRINT 'Insert ID 34'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Saldos')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (35, 'Saldos', 1)
	PRINT 'Insert ID 35'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'ConfirmacionManual')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (36, 'ConfirmacionManual', 31)
	PRINT 'Insert ID 36'
END
IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Mensajes Ordenes')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (37, 'Mensajes Ordenes', 1)
	PRINT 'Insert ID 37'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Traducciones')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (38, 'Traducciones', 255)
	PRINT 'Insert ID 38'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'ConfiguracionInterfaces')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (39, 'ConfiguracionInterfaces', 255)
	PRINT 'Insert ID 39'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'CachingManager')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (40, 'CachingManager', 1)
	PRINT 'Insert ID 40'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'RegistroUsuario')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (41, 'RegistroUsuario', 31)
	PRINT 'Insert ID 41'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'AdministracionUsuariosWeb')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (42, 'AdministracionUsuariosWeb', 31)
	PRINT 'Insert ID 42'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Menu Estado del sistema')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (43, 'Menu Estado del sistema', 1)
	PRINT 'Insert ID 43'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Graficos')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (44, 'Graficos', 1)
	PRINT 'Insert ID 44'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'PortfolioMercadoProductos')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (45, 'PortfolioMercadoProductos', 1)
	PRINT 'Insert ID 45'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'PuntasPortfolio')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (46, 'PuntasPortfolio', 1)
	PRINT 'Insert ID 46'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'DMA_GetPosicionAgenteLogueado')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (47, 'DMA_GetPosicionAgenteLogueado', 1)
	PRINT 'Insert ID 47'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'OPERACIONSTATUSCUSTOMQUERYBYID')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (48, 'OPERACIONSTATUSCUSTOMQUERYBYID', 1)
	PRINT 'Insert ID 48'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'MARKETDATACUSTOMQUERYBYID')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (49, 'MARKETDATACUSTOMQUERYBYID', 1)
	PRINT 'Insert ID 49'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'HISTORICODEORDENES')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (50, 'HISTORICODEORDENES', 1)
	PRINT 'Insert ID 50'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'ReRegistrarseSecurityList')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (51, 'ReRegistrarseSecurityList', 1)
	PRINT 'Insert ID 51'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'AltaOrdenExcel')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (52, 'AltaOrdenExcel', 31)
	PRINT 'Insert ID 52'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'GetUserSession')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (53, 'GetUserSession', 1)
	PRINT 'Insert ID 53'
END


DECLARE @IdRol SMALLINT 
DECLARE @IdAccion SMALLINT 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Usuarios' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 1' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Estado del sistema' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 2' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Cambio Clave' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 3' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'GetPermisosAcciones' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 4' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Ordenar Pantallas' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   256) 

      PRINT 'Insert ID 5' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'AppContext' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 6' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Menu' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 7' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Consultas Generales' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 8' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'MarketWatch' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 9' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'AppContext' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 10' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Menu' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 11' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'CachingManager' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 12' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Ejecutar Procesos Encadenados' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   256) 

      PRINT 'Insert ID 13' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Estado del sistema' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 14' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Configuracion Sistema' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   255) 

      PRINT 'Insert ID 15' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Consultas Auditoria' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 16' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Ordenes' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   21) 

      PRINT 'Insert ID 17' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Mercados' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1023) 

      PRINT 'Insert ID 18' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Monedas' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1023) 

      PRINT 'Insert ID 19' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Productos' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1023) 

      PRINT 'Insert ID 20' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Usuarios' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 21' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Rol' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 22' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Personas' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   255) 

      PRINT 'Insert ID 23' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Accion Rol' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 24' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Configuracion Seguridad' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 25' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Accion' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   29) 

      PRINT 'Insert ID 26' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'MarketWatch' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 27' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Portfolio' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   29) 

      PRINT 'Insert ID 28' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'PortfoliosComposicion' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   29) 

      PRINT 'Insert ID 29' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'AppContext' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 31' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Menu' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 32' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'ProductosPorMercado' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 33' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Autenticar Mobile' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 34' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Autenticar Api' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   17) 

      PRINT 'Insert ID 35' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'CierreMercadoInterno' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 36' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'PortfolioUsuario' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   285) 

      PRINT 'Insert ID 37' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Saldos' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 38' 
  END 

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 3
SELECT @IdAccion = IdAccion FROM shared_owner.Acciones WHERE Descripcion = 'Menu Estado del sistema'
IF @IdRol IS NOT NULL AND @IdAccion IS NOT NULL AND NOT EXISTS (SELECT 1 FROM shared_owner.AccionRol WHERE IdRol = @IdRol AND IdAccion = @IdAccion)
BEGIN
       INSERT INTO shared_owner.AccionRol (IdRol, IdAccion, Permiso) VALUES (@IdRol, @IdAccion, 1)
       PRINT 'Insert ID 39'
END

  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Ordenes' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   21) 

      PRINT 'Insert ID 40' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'AppContext' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 41' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Menu' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 42' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Portfolio' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   29) 

      PRINT 'Insert ID 43' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Saldos' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 44' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'PortfolioUsuario' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   29) 

      PRINT 'Insert ID 45' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'MarketWatch' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 46' 
  END

  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 8 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'CachingManager' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 47' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 9 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'AppContext' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 48' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 9 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Menu' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 49' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 9 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'AdministracionUsuariosWeb' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 50' 
  END 

  --Personas

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Personas' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   17) 

      PRINT 'Insert ID 52' 
  END 


SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 10 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Graficos' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 53' 
  END 


SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 10 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'PortfolioMercadoProductos' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 54' 
  END 
  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 10 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'PuntasPortfolio' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 55' 
  END 

  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 10

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'ORD_GetPosicionAgenteLogueado' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 56' 
  END 


    
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 11

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'OPERACIONSTATUSCUSTOMQUERYBYID' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 57' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 11

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'MARKETDATACUSTOMQUERYBYID' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 58' 
  END 


SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'HISTORICODEORDENES' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 50' 
  END 


 SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'ReRegistrarseSecurityList' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 51' 
  END 


 SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'AltaOrdenExcel' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 52' 
  END 

  
 SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'GetUserSession' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 53' 
  END 
