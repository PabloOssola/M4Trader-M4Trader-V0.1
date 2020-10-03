IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 101)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (101, 'Crear Orden')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 102)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (102, 'Eliminar Orden')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 103)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (103, 'Actualizar Orden')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 104)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (104, 'Confirmar Orden')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 105)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (105, 'Recibir Respuesta del Mercado')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 106)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (106, 'Enviar Modificacion al Mercado')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 107)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (107, 'Enviar Cancelacion al Mercado')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 108)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (108, 'Enviada al Mercado')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 109)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (109, 'Error al enviar al Mercado')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 110)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (110, 'Inicio Sesión')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 111)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (111, 'Usuario Bloqueado')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 112)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (112, 'Máximos Intentos')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 113)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (113, 'Usuario Inexistente')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 114)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (114, 'Usuario Baja Lógica')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 115)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (115, 'Usuario Bloqueado Por Cuenta Expirada')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 116)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (116, 'Usuario Bloqueado Por Tiempo Inactividad')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 117)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (117, 'Iniciando Servicio')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 118)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (118, 'Servicio Iniciado Correctamente')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 119)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (119, 'Servicio Iniciado Con Error')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 120)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (120, 'Procesado XML Correctamente')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 121)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (121, 'Procesado XML Con Error')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 122)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (122, 'Cierre Mercado Interno')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 123)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (123, 'Bloqueo de Orden')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 124)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (124, 'Desbloqueo de Orden')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 125)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (125, 'La sesión ha expirado.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 126)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (126, 'Error al cerrar sesión.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 127)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (127, 'Error inicio de sesión.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 128)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (128, 'Cierre de sesión exitoso.')
END


IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 129)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (129, 'Se ha rechazado la novedad de la entidad.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 130)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (130, 'No se ha rechazado la novedad de la entidad. Error técnico')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 131)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (131, 'Error al aprobar la novedad del producto.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 132)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (132, 'Se ha aprobado la novedad de la entidad')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 133)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (133, 'Error al cerrar sesión.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 134)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (134, 'El usuario alcanzó la cantidad máxima de intentos.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 135)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (135, 'Código genérico')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 136)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (136, 'Alta usuario')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 137)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (137, 'Eliminación usuario')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 138)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (138, 'Reset password')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 139)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (139, 'Actualiza User')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 140)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (140, 'Reactivación usuario')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE  Descripcion = 'Usuario inexistente')
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (141, 'Usuario inexistente')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE  Descripcion = 'Usuario dado de baja')
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (142, 'Usuario dado de baja')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE  Descripcion = 'Usuario desbloqueado por el administrador del sistema')
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (143, 'Usuario desbloqueado por el administrador del sistema')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE  Descripcion = 'Usuario bloqueado por el administrador del sistema')
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (144, 'Usuario bloqueado por el administrador del sistema')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE  Descripcion = 'Usuario bloqueado por cuenta expirada')
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (145, 'Usuario bloqueado por cuenta expirada')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE  Descripcion = 'Usuario bloqueado por exceder el límite de tiempo de inactividad')
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (146, 'Usuario bloqueado por exceder el límite de tiempo de inactividad')
END 
 
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 147)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (147, 'Se rechaza instrucciones de liquidación')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 148)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (148, 'Se Rectifica instruccion de liquidación')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 149)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (149, 'Iniciando Servicios de Aplicación')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 150)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (150, 'Inicio de servicio correctamente')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 151)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (151, 'Inicio de servicio con error')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 152)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (152, 'Iniciando Interface')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 153)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (153, 'Interface No inicializada. Error en configuracion.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 154)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (154, 'Interface Iniciada Correctamente')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 155)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (155, 'Interface Iniciada ConError')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 156)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (156, 'Dispatching Interface Starts')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 157)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (157, 'Dispatching Interface Succeeded')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 158)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (158, 'Dispatching Interface Error')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 159)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (159, 'Error Proccessing MarketData Fix Message');
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 160)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (160, 'AccionIncorrecta');
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 161)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (161, 'Error Proccessing CollateralReport Fix Message');
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 162)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (162, 'Re Registrar Security List');
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 163)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (163, 'Error Proccessing TradeCaptureReport Fix Message');
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 253)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (253, 'Item Queue Cancelled')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 254)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (254, 'Items on Queued')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 255)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (255, 'Ejecucion')
END