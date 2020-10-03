IF NOT EXISTS (SELECT 1 FROM orden_owner.Plazos WHERE IdPlazo = 1)
BEGIN
	INSERT INTO orden_owner.Plazos(IdPlazo, Descripcion) VALUES (1, 'CI')
	PRINT 'Insert CI'
END
ELSE
BEGIN 
	UPDATE orden_owner.Plazos SET Descripcion = 'CI' WHERE IdPlazo = 1
	PRINT 'UPDATE CI'
END
IF NOT EXISTS (SELECT 1 FROM orden_owner.Plazos WHERE IdPlazo = 2)
BEGIN
	INSERT INTO orden_owner.Plazos(IdPlazo, Descripcion) VALUES (2, '24hr')
	PRINT 'Insert 24hr'
END
ELSE
BEGIN 
	UPDATE orden_owner.Plazos SET Descripcion = '24hr' WHERE IdPlazo = 2
	PRINT 'UPDATE 24hr'
END
IF NOT EXISTS (SELECT 1 FROM orden_owner.Plazos WHERE IdPlazo = 3)
BEGIN
	INSERT INTO orden_owner.Plazos(IdPlazo, Descripcion) VALUES (3, '48hr')
	PRINT 'Insert 48hr'
END
ELSE
BEGIN 
	UPDATE orden_owner.Plazos SET Descripcion = '48hr' WHERE IdPlazo = 3
	PRINT 'UPDATE 48hr'
END
IF NOT EXISTS (SELECT 1 FROM orden_owner.Plazos WHERE IdPlazo = 4)
BEGIN
	INSERT INTO orden_owner.Plazos(IdPlazo, Descripcion) VALUES (4, '72Hr')
	PRINT 'Insert 72Hr'
END
ELSE
BEGIN 
	UPDATE orden_owner.Plazos SET Descripcion = '72Hr' WHERE IdPlazo = 4
	PRINT 'UPDATE 72Hr'
END
IF NOT EXISTS (SELECT 1 FROM orden_owner.Plazos WHERE IdPlazo = 5)
BEGIN
	INSERT INTO orden_owner.Plazos(IdPlazo, Descripcion) VALUES (5, '96Hr')
	PRINT 'Insert 96Hr'
END
ELSE
BEGIN 
	UPDATE orden_owner.Plazos SET Descripcion = '96Hr' WHERE IdPlazo = 5
	PRINT 'UPDATE 96Hr'
END
IF NOT EXISTS (SELECT 1 FROM orden_owner.Plazos WHERE IdPlazo = 6)
BEGIN
	INSERT INTO orden_owner.Plazos(IdPlazo, Descripcion) VALUES (6, 'Future')
	PRINT 'Insert Future'
END
ELSE
BEGIN 
	UPDATE orden_owner.Plazos SET Descripcion = 'Future' WHERE IdPlazo = 6
	PRINT 'UPDATE Future'
END
IF NOT EXISTS (SELECT 1 FROM orden_owner.Plazos WHERE IdPlazo = 7)
BEGIN
	INSERT INTO orden_owner.Plazos(IdPlazo, Descripcion) VALUES (7, 'When And If Issued')
	PRINT 'Insert When And If Issued'
END
ELSE
BEGIN 
	UPDATE orden_owner.Plazos SET Descripcion = 'When And If Issued' WHERE IdPlazo = 7
	PRINT 'UPDATE When And If Issued'
END
IF NOT EXISTS (SELECT 1 FROM orden_owner.Plazos WHERE IdPlazo = 8)
BEGIN
	INSERT INTO orden_owner.Plazos(IdPlazo, Descripcion) VALUES (8, 'Sellers Option')
	PRINT 'Insert Sellers Option'
END
ELSE
BEGIN 
	UPDATE orden_owner.Plazos SET Descripcion = 'Sellers Option' WHERE IdPlazo = 8
	PRINT 'UPDATE Sellers Option'
END
IF NOT EXISTS (SELECT 1 FROM orden_owner.Plazos WHERE IdPlazo = 9)
BEGIN
	INSERT INTO orden_owner.Plazos(IdPlazo, Descripcion) VALUES (9, '120Hr')
	PRINT 'Insert 120Hr'
END
ELSE
BEGIN 
	UPDATE orden_owner.Plazos SET Descripcion = '120Hr' WHERE IdPlazo = 9
	PRINT 'UPDATE 120Hr'
END
