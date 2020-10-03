CREATE PROCEDURE [orden_owner].[OPE_GetSaldoByPersonaYMoneda]
@IdMoneda tinyint,
@IdPersona int,
@Importe Decimal(18,4) OUTPUT 
  
AS

BEGIN    
 SET NOCOUNT ON     
   
	SELECT @Importe = Importe from orden_owner.saldos WHERE Idpersona = @IdPersona and IdMoneda = @IdMoneda
   
END