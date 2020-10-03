CREATE TABLE #AuxTablasCrear (Nombre VARCHAR(100))

Insert into #AuxTablasCrear (Nombre) VALUES ('Acciones')
Insert into #AuxTablasCrear (Nombre) VALUES ('AccionRol')
Insert into #AuxTablasCrear (Nombre) VALUES ('ConfiguracionSeguridad')
Insert into #AuxTablasCrear (Nombre) VALUES ('ConfiguracionSistema')
Insert into #AuxTablasCrear (Nombre) VALUES ('CustomizacionUsuario')
Insert into #AuxTablasCrear (Nombre) VALUES ('EstadoSistema')
Insert into #AuxTablasCrear (Nombre) VALUES ('HistoricoPassword')
Insert into #AuxTablasCrear (Nombre) VALUES ('LogAuditoria')
Insert into #AuxTablasCrear (Nombre) VALUES ('LogAuditoriaClases')
Insert into #AuxTablasCrear (Nombre) VALUES ('MensajesLiterales')
Insert into #AuxTablasCrear (Nombre) VALUES ('Mercados')
Insert into #AuxTablasCrear (Nombre) VALUES ('Monedas')
Insert into #AuxTablasCrear (Nombre) VALUES ('MotivosBaja')
Insert into #AuxTablasCrear (Nombre) VALUES ('Personas')
Insert into #AuxTablasCrear (Nombre) VALUES ('PersoneriaJuridica')
Insert into #AuxTablasCrear (Nombre) VALUES ('RechazosMercado')
Insert into #AuxTablasCrear (Nombre) VALUES ('Roles')
Insert into #AuxTablasCrear (Nombre) VALUES ('RolUsuario')
Insert into #AuxTablasCrear (Nombre) VALUES ('SeguridadPermisos')
Insert into #AuxTablasCrear (Nombre) VALUES ('Sesiones')
Insert into #AuxTablasCrear (Nombre) VALUES ('TiposEjecucionMercado')
Insert into #AuxTablasCrear (Nombre) VALUES ('TiposMoneda')
Insert into #AuxTablasCrear (Nombre) VALUES ('TiposPersona')
Insert into #AuxTablasCrear (Nombre) VALUES ('TiposVigencia')
Insert into #AuxTablasCrear (Nombre) VALUES ('Usuarios')

DECLARE @Tabla VARCHAR(100)
DECLARE MiCursor CURSOR FOR SELECT Nombre FROM #AuxTablasCrear
OPEN MiCursor
FETCH NEXT FROM MiCursor INTO @Tabla

WHILE @@FETCH_STATUS = 0
BEGIN

	EXECUTE ('IF (1 > (SELECT COUNT(1) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = ''shared_owner'' AND TABLE_NAME=''' + @Tabla + '''))
	SELECT * INTO shared_owner.' + @Tabla + ' FROM orden_owner.' + @Tabla)

	EXECUTE ('IF (1 > (SELECT COUNT(1) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = ''orden_owner'' AND TABLE_NAME=''' + @Tabla + '''))
	DROP TABLE orden_owner.' + @Tabla)
	
	FETCH NEXT FROM MiCursor into @Tabla
END
CLOSE MiCursor
DEALLOCATE MiCursor   
