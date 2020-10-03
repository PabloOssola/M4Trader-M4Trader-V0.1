CREATE PROCEDURE [orden_owner].[AMB_AlterSequence]
@NombreSequence varchar(1000),
@NombreTabla varchar(1000),
@NombreCampo varchar(1000)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Valor varchar(100)
	SELECT convert(varchar(100), '') as Valor INTO #SequenceTemporal
	EXEC ('INSERT INTO #SequenceTemporal SELECT ISNULL(MAX(' + @NombreCampo + '), 0)+1 FROM ' + @NombreTabla)
    SELECT @Valor = Valor FROM #SequenceTemporal WHERE Valor <> ''
	DROP TABLE #SequenceTemporal
	EXEC ('ALTER SEQUENCE ' + @NombreSequence + ' RESTART WITH ' + @Valor + ' INCREMENT BY 1 CACHE')

END