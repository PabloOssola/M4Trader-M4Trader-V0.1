CREATE PROCEDURE [orden_owner].[OPE_ImpactarEnSaldoHistoricosOperacionesDelDia]
@FechaSistema Datetime
AS

BEGIN    
 SET NOCOUNT ON     
 IF OBJECT_ID('tempdb..#TEMP1') IS NOT NULL
			DROP TABLE #TEMP1;


SELECT 
			IdPersona,
			IdMoneda,
			--IdTipoProducto,
			SUM(CASE WHEN t.IdtipoMovimiento = 1 THEN (t.importe)  ELSE 0 END) as MontoAPagar,
			SUM(CASE WHEN (t.IdtipoMovimiento = 2 or (t.idmovimiento = 3 and t.IdEstado = 2)) THEN (t.importe ) ELSE 0 END) as MontoACobrar
			 INTO #TEMP1
	FROM  orden_owner.movimientossaldo t
	WHERE t.ImpactoEnSaldo = 0
	group by IdPersona, IdMoneda 


INSERT INTO [orden_owner].[SaldosHistoricos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta]
           ,[Fecha])
SELECT 
		t.IdPersona,
		2,
		(Coalesce(s.importe, 0) + t.MontoACobrar) - t.MontoAPagar,
		t.IdMoneda,
		s.numeroCuenta,
		s.idtipoCuenta,
		@FechaSistema
FROM 	#TEMP1 as t
INNER JOIN orden_owner.SaldosHistoricos as s on (s.IdPersona = t.IdPersona and s.idMoneda = t.IdMoneda )


UPDATE  orden_owner.movimientossaldo SET ImpactoEnSaldo = 1 WHERE ImpactoEnSaldo = 0
 
END