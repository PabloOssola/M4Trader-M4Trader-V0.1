CREATE PROCEDURE [dbo].[AMB_CodigosMensajes]
@Codigo varchar(100),
@Mensaje varchar(500),
@Idioma varchar(5) = 'es-AR'
AS
BEGIN
	SET NOCOUNT ON;
	
	begin tran
	BEGIN TRY


	IF (1 > (SELECT COUNT(1) FROM shared_owner.MensajesLiterales WHERE Idioma = @Idioma AND Referencia = @Codigo))
	BEGIN
		INSERT INTO shared_owner.MensajesLiterales (Idioma, Referencia, Valor) VALUES (@Idioma, @Codigo, @Mensaje)
	END
	ELSE
	BEGIN
		UPDATE shared_owner.MensajesLiterales 
		SET Valor = @Mensaje
		WHERE Idioma = @Idioma
		AND Referencia = @Codigo
	END
	
	COMMIT	
	END TRY

	BEGIN CATCH
		SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage; 
		ROLLBACK
		RAISERROR('Se produjo algun error en el script',16,10)
	END CATCH	

END