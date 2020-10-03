CREATE PROCEDURE [orden_owner].[OPE_GenerarMovimientosByPersonaYMoneda]
@IdTipoMovimiento int,
@IdMoneda tinyint,
@IdPersona int,
@Importe Decimal(18,4),
@IdPropietario int,
@ImpactoEnSaldo bit,
@IdEstado int  
AS

BEGIN    
 SET NOCOUNT ON     
   
   INSERT INTO [orden_owner].[MovimientosSaldo]
           ( [IdTipoMovimiento]
           ,[IdMoneda]
           ,[IdPersona]
           ,[Importe]
           ,[IdPropietario]
           ,[ImpactoEnSaldo]
           ,[IdEstado])
     VALUES
           (@IdTipoMovimiento
           ,@IdMoneda
           ,@IdPersona
           ,@Importe
           ,@IdPropietario
           ,@ImpactoEnSaldo
           ,@IdEstado) 
     
END