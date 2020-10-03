IF EXISTS(SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Portfolios')
BEGIN
	UPDATE shared_owner.LogAuditoriaClases
	SET NombreEntidad = 'Portfolio'
	WHERE NombreEntidad = 'Portfolios' 
	PRINT 'Portfolios Cambio a Portfolio'
END

IF EXISTS(SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'ProductosPorMercado')
BEGIN
	UPDATE shared_owner.LogAuditoriaClases
	SET NombreEntidad = 'ProductoPorMercado'
	WHERE NombreEntidad = 'ProductosPorMercado' 
	PRINT 'ProductosPorMercado Cambio a ProductoPorMercado'
END

IF EXISTS(SELECT 1 FROM fix_owner.MensajesRecibidosOrdenes WHERE Valor IS NULL)
BEGIN
	DELETE fix_owner.MensajesRecibidosOrdenes
	WHERE Valor IS NULL
	PRINT 'delete MensajesRecibidosOrdenes'
END
