IF NOT EXISTS (SELECT 1 FROM fix_owner.TipoNegociacion WHERE Codigo = 'C')
BEGIN
	INSERT INTO fix_owner.TipoNegociacion (Codigo, Descripcion) VALUES ('C', 'Vta/Cmp CPC')
	PRINT 'Insert ID 1'
END
