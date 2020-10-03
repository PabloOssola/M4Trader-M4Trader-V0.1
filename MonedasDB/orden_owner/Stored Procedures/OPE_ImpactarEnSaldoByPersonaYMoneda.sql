CREATE PROCEDURE [orden_owner].[OPE_ImpactarEnSaldoByPersonaYMoneda]
@IdMoneda tinyint,
@IdPersona int,
@Importe Decimal(18,4),
@IdTipoMovimiento int
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
               ,@Importe
               ,@IdMoneda
               ,Null
               ,1
               ,0)
   END
   ELSE
   BEGIN
       UPDATE [orden_owner].[Saldos]
       SET [Importe] =  case @IdTipoMovimiento 
						    WHEN 1 THEN Importe - @Importe
						    WHEN 2 THEN Importe + @Importe
						    WHEN 3 THEN Importe + @Importe
						    END,
		    [SaldoPendienteAcreditacion] = case @IdTipoMovimiento 
										    WHEN 3 THEN SaldoPendienteAcreditacion - @Importe
										    END
       WHERE 
		    IdMoneda = @IdMoneda 
		    and IdPersona = @IdPersona
    END
END