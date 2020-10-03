DECLARE @value VARCHAR(500)

SET @value = 'Mobile'
IF NOT EXISTS(SELECT 1 FROM orden_owner.SourcesApplication WHERE IdSourceApplication = 1)
BEGIN
	INSERT INTO orden_owner.SourcesApplication (IdSourceApplication, Descripcion) VALUES(1, @value)

	PRINT @value + 'Insertado Mobile'
END

SET @value = 'Web'
IF NOT EXISTS(SELECT 1 FROM orden_owner.SourcesApplication WHERE IdSourceApplication = 2)
BEGIN
	INSERT INTO orden_owner.SourcesApplication (IdSourceApplication, Descripcion) VALUES(2, @value)

	PRINT @value + 'Insertado Web'
END


SET @value = 'Api'
IF NOT EXISTS(SELECT 1 FROM orden_owner.SourcesApplication WHERE IdSourceApplication = 3)
BEGIN
	INSERT INTO orden_owner.SourcesApplication (IdSourceApplication, Descripcion) VALUES(3, @value)

	PRINT @value + 'Insertado Api'
END

SET @value = 'WebExterna'
IF NOT EXISTS(SELECT 1 FROM orden_owner.SourcesApplication WHERE IdSourceApplication = 4)
BEGIN
	INSERT INTO orden_owner.SourcesApplication (IdSourceApplication, Descripcion) VALUES(4, @value)

	PRINT @value + 'Insertado WebExterna'
END

SET @value = 'DMA'
IF NOT EXISTS(SELECT 1 FROM orden_owner.SourcesApplication WHERE IdSourceApplication = 5)
BEGIN
	INSERT INTO orden_owner.SourcesApplication (IdSourceApplication, Descripcion) VALUES(5, @value)

	PRINT @value + 'Insertado DMA'
END

SET @value = 'EXCEL'
IF NOT EXISTS(SELECT 1 FROM orden_owner.SourcesApplication WHERE IdSourceApplication = 6)
BEGIN
	INSERT INTO orden_owner.SourcesApplication (IdSourceApplication, Descripcion) VALUES(6, @value)

	PRINT @value + 'Insertado DMA'
END