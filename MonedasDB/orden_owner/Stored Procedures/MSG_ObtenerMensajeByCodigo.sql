CREATE PROCEDURE orden_owner.MSG_ObtenerMensajeByCodigo
@Codigo  VARCHAR(8),      
@Mensaje VARCHAR(max) output
AS      
BEGIN
	SELECT @Mensaje = Valor
	FROM shared_owner.MensajesLiterales
	WHERE Idioma = 'es-AR' AND Referencia = @Codigo
    
END
