IF NOT EXISTS (SELECT 1 FROM shared_owner.Monedas WHERE codigo = '$')
BEGIN
	INSERT INTO shared_owner.Monedas (IdMoneda, Codigo, Descripcion, TipoMoneda, CodigoISO) VALUES (1, '$','Pesos', 1, 'ARS')
	PRINT 'Insert Moneda ID 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Monedas WHERE codigo = 'D')
BEGIN
	INSERT INTO shared_owner.Monedas (IdMoneda, Codigo, Descripcion, TipoMoneda, CodigoISO) VALUES (2, 'D','Dolar', 1, 'USD')
	PRINT 'Insert Moneda ID 2'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Monedas WHERE codigo = 'E')
BEGIN
	INSERT INTO shared_owner.Monedas (IdMoneda, Codigo, Descripcion, TipoMoneda, CodigoISO) VALUES (3, 'E','Euro', 1, 'EUR')
	PRINT 'Insert Moneda ID 3'
END
