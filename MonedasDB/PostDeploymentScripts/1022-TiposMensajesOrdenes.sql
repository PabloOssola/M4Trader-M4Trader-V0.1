IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = '')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (0, '','Desconocido')
	  PRINT 'Insert ID 0'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = 'A')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (1, 'A','ALTA_ORDEN')
	  PRINT 'Insert ID 1'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = 'W')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (2, 'W','ALTA_ORDEN_MULTIPLE')
	  PRINT 'Insert ID 2'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = 'C')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (3, 'C','CANCELAR_ORDEN')
	  PRINT 'Insert ID 3'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = 'M')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (4, 'M','MODIFICAR_ORDEN')
	  PRINT 'Insert ID 4'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = 'X')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (5, 'X','MODIFICAR_ORDEN_MULTIPLE')
	  PRINT 'Insert ID 5'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = 'S')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (6, 'S','STATUS_MASIVO_REQUEST')
	  PRINT 'Insert ID 6'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = 'E')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (7, 'E','REPORTE_ESTADO_EJECUCION')
	  PRINT 'Insert ID 7'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = 'B')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (8, 'B','NOVEDAD')
	  PRINT 'Insert ID 8'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = 'P')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (9, 'P','CAMBIO_PASSWORD')
	  PRINT 'Insert ID 9'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = 'AE')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (10, 'AE','TRADE_CAPTURE_REPORT')
	  PRINT 'Insert ID 10'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = '9')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (11, '9','CANCEL_REJECTED')
	  PRINT 'Insert ID 11'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = 'j')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (12, 'j','MESSAGE_REJECTED')
	  PRINT 'Insert ID 12'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = 'BA')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (13, 'BA','COLLATERAL_REPORT')
	  PRINT 'Insert ID 13'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesOrdenes WHERE Codigo = '0')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesOrdenes(IdTipoMensajeOrden, Codigo, Descripcion) VALUES (14, '0','LATIDO')
	  PRINT 'Insert ID 14'
END