CREATE PROCEDURE [orden_owner].[SAL_ActualizarEstado]
@IdEstado int,
@idMovimiento int 
AS

BEGIN    
 SET NOCOUNT ON     
   
   UPDATE [orden_owner].[MovimientosSaldo]
   SET [IdEstado] =  @IdEstado  
   WHERE 
		IdMovimiento = @idMovimiento 
END