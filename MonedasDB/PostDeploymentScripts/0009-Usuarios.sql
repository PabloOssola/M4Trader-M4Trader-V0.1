IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'Usuario Proceso' OR Nombre = 'Usuario Proceso')
BEGIN
	INSERT INTO shared_owner.Usuarios(IdUsuario, Username, Pass, Nombre, Proceso, NoControlarInactividad, IdPersona)
	VALUES (1,'UsuarioProceso', '989FA7EC5802BB6283C6B3741923C158','Usuario Proceso',1,1,1)
	print 'Insert proceso'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'admin')
BEGIN
	INSERT INTO shared_owner.Usuarios (IdUsuario, Username, Pass, Nombre, CantidadIntentos, Bloqueado, Proceso, BajaLogica, UltimaModificacionPassword, 
		UltimoLoginExitoso, NoControlarInactividad, IdPersona, LoginRealizado)
	VALUES (2, 'admin', '1A1DC91C907325C69271DDF0C944BC72', 'Administrador', 0, 0, 0, 0, GETDATE(), NULL, 0, 1, 0)
	PRINT 'Insert admin'
END


--INSERTAR SEGUN EL AMBIENTE MAE_DMA o Rofex_Arpenta_Byma
PRINT 'INSERTAR SEGUN EL AMBIENTE MAE_DMA o Rofex_Arpenta_Byma'