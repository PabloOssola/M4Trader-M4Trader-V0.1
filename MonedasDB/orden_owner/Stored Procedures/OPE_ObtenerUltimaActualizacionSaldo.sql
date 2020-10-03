CREATE PROCEDURE [orden_owner].[OPE_ObtenerUltimaActualizacionSaldo]
@IdMoneda tinyint,
@IdPersona int,
@UltimaActualizacion timestamp OUTPUT 
  
AS

BEGIN    
 SET NOCOUNT ON     
   
	SELECT @UltimaActualizacion = UltimaActualizacion from orden_owner.saldos WHERE Idpersona = @IdPersona and IdMoneda = @IdMoneda
   
END