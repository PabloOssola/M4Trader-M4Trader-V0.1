IF NOT EXISTS (SELECT 1 FROM shared_owner.RechazosMercado WHERE IdRechazoMercado=1)
BEGIN
	INSERT INTO shared_owner.RechazosMercado (IdRechazoMercado,Codigo,Descripcion) 
	VALUES (1,'M','Indefinido Por Mercado')
	PRINT 'Insert ID 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RechazosMercado WHERE IdRechazoMercado=2)
BEGIN
	INSERT INTO shared_owner.RechazosMercado (IdRechazoMercado,Codigo,Descripcion) 
	VALUES (2,'S','Especie Desconocida')
	PRINT 'Insert ID 2'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RechazosMercado WHERE IdRechazoMercado=3)
BEGIN
	INSERT INTO shared_owner.RechazosMercado (IdRechazoMercado,Codigo,Descripcion) 
	VALUES (3,'C','Mercado Cerrado')
	PRINT 'Insert ID 3'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RechazosMercado WHERE IdRechazoMercado=4)
BEGIN
	INSERT INTO shared_owner.RechazosMercado (IdRechazoMercado,Codigo,Descripcion) 
	VALUES (4,'E','OrdenExcedeLimite')
	PRINT 'Insert ID 4'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RechazosMercado WHERE IdRechazoMercado=5)
BEGIN
	INSERT INTO shared_owner.RechazosMercado (IdRechazoMercado,Codigo,Descripcion) 
	VALUES (5,'L','Demasiado Tarde Para Entrar')
	PRINT 'Insert ID 5'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RechazosMercado WHERE IdRechazoMercado=6)
BEGIN
	INSERT INTO shared_owner.RechazosMercado (IdRechazoMercado,Codigo,Descripcion) 
	VALUES (6,'U','Orden Desconocida')
	PRINT 'Insert ID 6'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RechazosMercado WHERE IdRechazoMercado=7)
BEGIN
	INSERT INTO shared_owner.RechazosMercado (IdRechazoMercado,Codigo,Descripcion) 
	VALUES (7,'D','Orden Duplicada')
	PRINT 'Insert ID 7'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RechazosMercado WHERE IdRechazoMercado=8)
BEGIN
	INSERT INTO shared_owner.RechazosMercado (IdRechazoMercado,Codigo,Descripcion) 
	VALUES (8,'B','Orden Verbal Duplicada')
	PRINT 'Insert ID 8'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RechazosMercado WHERE IdRechazoMercado=9)
BEGIN
	INSERT INTO shared_owner.RechazosMercado (IdRechazoMercado,Codigo,Descripcion) 
	VALUES (9,'V','Orden Viciada')
	PRINT 'Insert ID 9'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RechazosMercado WHERE IdRechazoMercado=10)
BEGIN
	INSERT INTO shared_owner.RechazosMercado (IdRechazoMercado,Codigo,Descripcion) 
	VALUES (10,'O','Otros')
	PRINT 'Insert ID 10'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.RechazosMercado WHERE IdRechazoMercado=11)
BEGIN
	INSERT INTO shared_owner.RechazosMercado (IdRechazoMercado,Codigo,Descripcion) 
	VALUES (11,'Y','Sin Motivo')
	PRINT 'Insert ID 11'
END
