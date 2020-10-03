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


  
  
 SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'RefrescarCacheCommand' 

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

      PRINT 'Insert ID RefrescarCacheCommand para rol con valornumerico=3' 
  END 
  

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Chat' 

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

      PRINT 'Insert ID Chat para rol con valornumerico=2' 
  END 
