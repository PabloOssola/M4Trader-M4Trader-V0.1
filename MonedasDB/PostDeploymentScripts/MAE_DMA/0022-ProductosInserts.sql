DECLARE @IdTipoProducto TINYINT
DECLARE @Producto VARCHAR(32)
SELECT @IdTipoProducto = @IdTipoProducto FROM orden_owner.TiposProducto WHERE Descripcion = 'Bonos'
IF (@IdTipoProducto IS NULL)
BEGIN
	SET @IdTipoProducto = 3
END

DECLARE @IdMoneda TINYINT
DECLARE @CodigoMoneda VARCHAR(15)
SELECT @IdMoneda = IdMoneda, @CodigoMoneda = Descripcion FROM shared_owner.Monedas WHERE codigo = '$'
IF (@IdMoneda IS NULL)
BEGIN
	SET @IdMoneda = 1
	SET @CodigoMoneda = 'Pesos'
END

SET @Producto = 'OCTGA3ABR19'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, BajaLogica, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 0, 0, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA31MAY19'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, BajaLogica, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 0, 0, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA28JUN19'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA31JUL19'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA30AGO19'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA30SEP19'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA30OCT19'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END 

SET @Producto = 'OCTGA29NOV19'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA30DIC19'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA31ENE20'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA28FEB20'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA29MAR20'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA30ABR20'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA31MAY20'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA30JUN20'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END

SET @Producto = 'OCTGA31JUL20'
IF NOT EXISTS (SELECT 1 FROM orden_owner.Productos WHERE codigo = @Producto AND IdMoneda = @IdMoneda)
BEGIN
        INSERT INTO orden_owner.Productos(Codigo, Descripcion, ISIN, IdMoneda, IdTipoProducto, Habilitado, CantidadContrato, SegmentMarketId) VALUES (@Producto,@Producto + ' ' + @CodigoMoneda,@Producto, @IdMoneda, @IdTipoProducto, 1, 10000, 'CPC2')
        PRINT 'Insert ' + @Producto + ' ARS'
END
