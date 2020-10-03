CREATE PROCEDURE [orden_owner].[Nov_AgregarDespositoEnSaldoByPersonaYMoneda]
@IdMoneda tinyint,
@IdPersona int,
@Importe Decimal(18,4) ,
@Cuenta nvarchar(50)
AS

BEGIN    
 SET NOCOUNT ON     
   
   IF(1 > (SELECT COUNT(*) FROM  [orden_owner].[Saldos] WHERE  idMoneda = @IdMoneda and IdPersona = @IdPersona))
   BEGIN
       INSERT INTO [orden_owner].[Saldos]
               ( [IdPersona]
               ,[IdTipoProducto]
               ,[Importe]
               ,[IdMoneda]
               ,[NumeroCuenta]
               ,[IdTipoCuenta]
               ,[SaldoPendienteAcreditacion])
         VALUES
               (@IdPersona
               ,2
               ,0
               ,@IdMoneda
               ,@Cuenta
               ,1
               ,@Importe)
   END
   ELSE
   BEGIN
       UPDATE [orden_owner].[Saldos]
       SET [SaldoPendienteAcreditacion] = SaldoPendienteAcreditacion + @Importe 
       WHERE 
		    IdMoneda = @IdMoneda 
		    and IdPersona = @IdPersona
    END
END