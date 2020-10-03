DECLARE @BASE_FIX VARCHAR(100)
DECLARE @BASE_MIX VARCHAR(100)

/*****PONER NOMBRES DE BASES ************************/
SET @BASE_FIX = 'FIX_DATABASE'
SET @BASE_MIX = 'MIX_DATABASE'

DECLARE @Tabla VARCHAR(100)
DECLARE MiCursor CURSOR FOR SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_SCHEMA = 'fix_owner'
OPEN MiCursor
FETCH NEXT FROM MiCursor INTO @Tabla

WHILE @@FETCH_STATUS = 0
BEGIN

	EXECUTE ('IF (1 > (SELECT COUNT(1) FROM ' + @BASE_MIX + '.information_schema.COLUMNS WHERE (TABLE_SCHEMA = ''fix_owner'' OR TABLE_SCHEMA = ''shared_owner'') AND TABLE_NAME=''' + @Tabla + '''))
	SELECT * INTO ' + @BASE_MIX + '.fix_owner.' + @Tabla + ' FROM ' + @BASE_FIX + '.fix_owner.' + @Tabla)

	FETCH NEXT FROM MiCursor into @Tabla
END
CLOSE MiCursor
DEALLOCATE MiCursor