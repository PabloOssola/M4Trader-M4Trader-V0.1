CREATE PROCEDURE [dbo].[AMB_Sequence]
@NombreSequence varchar(1000),
@NombreTabla varchar(1000),
@NombreCampo varchar(1000)
AS
BEGIN
       SET NOCOUNT ON;
       
       begin tran
       BEGIN TRY

       DECLARE @START_SEQ nvarchar(1255)
       DECLARE @SQL varchar(1255)
       DECLARE @Valor varchar(100)
	   DECLARE @MensajeError varchar(1255)
	   SELECT @MensajeError = 'Se produjo algun error en el script' + @NombreSequence

       SELECT convert(varchar(100), '') as Valor INTO #SequenceTemporal

       SET @START_SEQ = 'INSERT INTO #SequenceTemporal SELECT ISNULL(MAX(' + @NombreCampo + '), 0)+1 FROM ' + @NombreTabla
       EXECUTE sp_executesql @START_SEQ
       SELECT @Valor = Valor FROM #SequenceTemporal WHERE Valor <> ''
       DROP TABLE #SequenceTemporal
       
       IF OBJECT_ID(@NombreSequence) IS NOT NULL
       BEGIN
             SET @SQL = 'ALTER SEQUENCE ' + @NombreSequence + ' RESTART WITH ' + @Valor + ' INCREMENT BY 1 CACHE'
             EXEC(@SQL) 
       END
       ELSE
       BEGIN
             SET @SQL = 'CREATE SEQUENCE ' + @NombreSequence + ' START WITH ' + @Valor + ' INCREMENT BY 1 CACHE'
             EXEC(@SQL) 
       END
       
       COMMIT 
       END TRY

       BEGIN CATCH
             SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage; 
             ROLLBACK
             RAISERROR(@MensajeError,16,10)
       END CATCH    

END