IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesMarketData WHERE Codigo = '')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesMarketData(IdTipoMensajeMarketData, Codigo, Descripcion) VALUES (0, '','Desconocido')
	  PRINT 'Insert ID 0'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesMarketData WHERE Codigo = 'X' COLLATE Latin1_General_CS_AS)
BEGIN
	  INSERT INTO fix_owner.TiposMensajesMarketData(IdTipoMensajeMarketData, Codigo, Descripcion) VALUES (1, 'X','Refresh')
	  PRINT 'Insert ID 1'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesMarketData WHERE Codigo = 'W' COLLATE Latin1_General_CS_AS)
BEGIN
	  INSERT INTO fix_owner.TiposMensajesMarketData(IdTipoMensajeMarketData, Codigo, Descripcion) VALUES (2, 'W','FULL')
	  PRINT 'Insert ID 2'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesMarketData WHERE Codigo = 'x' COLLATE Latin1_General_CS_AS)
BEGIN
	  INSERT INTO fix_owner.TiposMensajesMarketData(IdTipoMensajeMarketData, Codigo, Descripcion) VALUES (3, 'x','SECURITY_LIST')
	  PRINT 'Insert ID 3'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesMarketData WHERE Codigo = 'B' COLLATE Latin1_General_CS_AS)
BEGIN
	  INSERT INTO fix_owner.TiposMensajesMarketData(IdTipoMensajeMarketData, Codigo, Descripcion) VALUES (4, 'B','NOVEDAD')
	  PRINT 'Insert ID 4'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesMarketData WHERE Codigo = 'P' COLLATE Latin1_General_CS_AS)
BEGIN
	  INSERT INTO fix_owner.TiposMensajesMarketData(IdTipoMensajeMarketData, Codigo, Descripcion) VALUES (5, 'P','CAMBIO_PASSWORD')
	  PRINT 'Insert ID 5'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesMarketData WHERE Codigo = 'h' COLLATE Latin1_General_CS_AS)
BEGIN
	  INSERT INTO fix_owner.TiposMensajesMarketData(IdTipoMensajeMarketData, Codigo, Descripcion) VALUES (6, 'h','TRADE_SESSION_STATUS')
	  PRINT 'Insert ID 6'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesMarketData WHERE Codigo = 'BA' COLLATE Latin1_General_CS_AS)
BEGIN
	  INSERT INTO fix_owner.TiposMensajesMarketData(IdTipoMensajeMarketData, Codigo, Descripcion) VALUES (7, 'BA','COLLATERAL_REPORT')
	  PRINT 'Insert ID 7'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesMarketData WHERE Codigo = 'AE')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesMarketData(IdTipoMensajeMarketData, Codigo, Descripcion) VALUES (8, 'AE','TRADE_CAPTURE_REPORT')
	  PRINT 'Insert ID 8'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesMarketData WHERE Codigo = '0')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesMarketData(IdTipoMensajeMarketData, Codigo, Descripcion) VALUES (9, '0','LATIDO')
	  PRINT 'Insert ID 9'
END
IF NOT EXISTS (SELECT 1 FROM fix_owner.TiposMensajesMarketData WHERE Codigo = 'z')
BEGIN
	  INSERT INTO fix_owner.TiposMensajesMarketData(IdTipoMensajeMarketData, Codigo, Descripcion) VALUES (10, 'z','LISTADO_RUEDAS')
	  PRINT 'Insert ID 10'
END