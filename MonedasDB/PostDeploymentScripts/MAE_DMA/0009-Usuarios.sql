IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'Agente HSBC' OR Nombre = 'Agente HSBC')
BEGIN
	INSERT INTO shared_owner.Usuarios(Username, Pass, Nombre, CantidadIntentos, Bloqueado, Proceso, BajaLogica, UltimaModificacionPassword, 
		UltimoLoginExitoso, NoControlarInactividad, IdPersona, LoginRealizado)
	VALUES ('Agente HSBC', '1A1DC91C907325C69271DDF0C944BC72','Agente HSBC', 0, 0, 0, 0, GETDATE(), NULL, 0, (SELECT IdParty FROM shared_owner.Parties WHERE [Name] = 'HSBC'), 0)
	print 'Insert Agente HSBC'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'Agente BBVA' OR Nombre = 'Agente BBVA')
BEGIN
	INSERT INTO shared_owner.Usuarios(Username, Pass, Nombre, CantidadIntentos, Bloqueado, Proceso, BajaLogica, UltimaModificacionPassword, 
		UltimoLoginExitoso, NoControlarInactividad, IdPersona, LoginRealizado)
	VALUES ('Agente BBVA', '1A1DC91C907325C69271DDF0C944BC72','Agente BBVA', 0, 0, 0, 0, GETDATE(), NULL, 0, (SELECT IdParty FROM shared_owner.Parties WHERE [Name] = 'BBVA'), 0)
	print 'Insert Agente BBVA'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'AdminWebBBVA' OR Nombre = 'Administrador Web BBVA')
BEGIN
	INSERT INTO shared_owner.Usuarios(Username, Pass, Nombre, CantidadIntentos, Bloqueado, Proceso, BajaLogica, UltimaModificacionPassword, 
		UltimoLoginExitoso, NoControlarInactividad, IdPersona, LoginRealizado)
	VALUES ('AdminWebBBVA', '1A1DC91C907325C69271DDF0C944BC72','Administrador Web BBVA', 0, 0, 0, 0, GETDATE(), NULL, 0, (SELECT IdParty FROM shared_owner.Parties WHERE [Name] = 'BBVA'), 0)
	print 'Insert AdminWeb BBVA'
END
