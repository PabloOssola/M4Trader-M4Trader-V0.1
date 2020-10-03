IF NOT EXISTS (SELECT 1 FROM shared_owner.Mercados WHERE codigo = 'MAE')
BEGIN
	INSERT INTO shared_owner.Mercados (IdMercado, Codigo, Descripcion, ProductoHabilitadoDefecto) VALUES (1, 'MAE','Mercado Abierto Electronico S.A.', 1)
	PRINT 'Insert ID 1'
END

--INSERTAR SEGUN EL AMBIENTE MAE_DMA o Rofex_Arpenta_Byma
PRINT 'INSERTAR SEGUN EL AMBIENTE MAE_DMA o Rofex_Arpenta_Byma'
