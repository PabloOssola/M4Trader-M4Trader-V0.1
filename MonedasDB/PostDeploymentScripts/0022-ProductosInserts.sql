DECLARE @IdTipoProducto TINYINT
SELECT @IdTipoProducto = @IdTipoProducto FROM orden_owner.TiposProducto WHERE Descripcion = 'Bonos'
IF (@IdTipoProducto IS NULL)
BEGIN
	SET @IdTipoProducto = 3
END


DECLARE @IdMoneda TINYINT
DECLARE @CodigoMoneda VARCHAR(15)
SELECT @IdMoneda = IdMoneda, @CodigoMoneda = Descripcion FROM shared_owner.Monedas WHERE codigo = 'D'
IF (@IdMoneda IS NULL)
BEGIN
	SET @IdMoneda = 2
	SET @CodigoMoneda = 'Dolar'
END

IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = 'AY24D')
BEGIN
        INSERT INTO orden_owner.Productos(IdProducto, Codigo, Descripcion, IdMoneda, IdTipoProducto) VALUES (37, 'AY24D','AY24D ' + @CodigoMoneda, @IdMoneda, @IdTipoProducto)
        PRINT 'Insert ID 37'
END

SET @IdMoneda = NULL
SELECT @IdMoneda = IdMoneda, @CodigoMoneda = Descripcion FROM shared_owner.Monedas WHERE codigo = '$'
IF (@IdMoneda IS NULL)
BEGIN
	SET @IdMoneda = 1
	SET @CodigoMoneda = 'Pesos'
END

IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = 'CL3M8')
BEGIN
        INSERT INTO orden_owner.Productos(IdProducto, Codigo, Descripcion, IdMoneda, IdTipoProducto) VALUES (73991, 'CL3M8','LETRA CHACO CL1 02/03/2018 ' + @CodigoMoneda, @IdMoneda, @IdTipoProducto)
        PRINT 'Insert ID 73991'
END