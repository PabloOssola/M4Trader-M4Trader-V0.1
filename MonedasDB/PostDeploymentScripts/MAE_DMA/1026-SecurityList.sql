DECLARE @Producto VARCHAR(32)
SET @Producto = 'OCTGA30ABR19'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA31MAY19'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA28JUN19'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA31JUL19'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA30AGO19'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA30SET19'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA30OCT19'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA29NOV19'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA30DIC19'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA31ENE20'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA28FEB20'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA29MAR20'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA30ABR20'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA31MAY20'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA30JUN20'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

SET @Producto = 'OCTGA31JUL20'
IF NOT EXISTS (SELECT 1 FROM shared_owner.SecurityList WHERE CodigoProducto = @Producto)
BEGIN
	INSERT INTO shared_owner.SecurityList (CodigoProducto, IdMercado, Habilitada) VALUES (@Producto, 1, 1)
	PRINT 'Insert ID ' + @Producto
END

