IF (1 > (SELECT COUNT(1) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'orden_owner' AND TABLE_NAME='Ofertas' AND COLUMN_NAME = 'Valorizacion'))
BEGIN
	ALTER TABLE orden_owner.Ofertas ADD Valorizacion DECIMAL(24, 8) NULL
	PRINT 'ADD orden_owner.Ofertas.Valorizacion'
END
ELSE
BEGIN
	ALTER TABLE orden_owner.Ofertas ALTER COLUMN Valorizacion DECIMAL(24,8) NULL
	PRINT 'ALTER orden_owner.Ofertas.Valorizacion'
END

IF (1 > (SELECT COUNT(1) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'orden_owner' AND TABLE_NAME='Ordenes' AND COLUMN_NAME = 'Valorizacion'))
BEGIN
	ALTER TABLE orden_owner.Ordenes ADD Valorizacion DECIMAL(24, 8) NULL
	PRINT 'ADD orden_owner.Ordenes.Valorizacion'
END
ELSE
BEGIN
	ALTER TABLE orden_owner.Ordenes ALTER COLUMN Valorizacion DECIMAL(24,8) NULL
	PRINT 'ALTER orden_owner.Ordenes.Valorizacion'
END

IF (1 > (SELECT COUNT(1) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'orden_owner' AND TABLE_NAME='OrdenOperacion' AND COLUMN_NAME = 'Valorizacion'))
BEGIN
	ALTER TABLE orden_owner.OrdenOperacion ADD Valorizacion DECIMAL(24, 8) NULL
	PRINT 'ADD orden_owner.OrdenOperacion.Valorizacion'
END
ELSE
BEGIN
	ALTER TABLE orden_owner.OrdenOperacion ALTER COLUMN Valorizacion DECIMAL(24,8) NULL
	PRINT 'ALTER orden_owner.OrdenOperacion.Valorizacion'
END
