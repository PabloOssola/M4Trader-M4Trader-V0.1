CREATE PROCEDURE orden_owner.SAL_OBTENERMOVIMIENTOSSALDOSBYIDPROPIETARIO  
@idPropietario int
AS  
BEGIN  

  
SELECT [IdMovimiento]
      ,[IdTipoMovimiento]
      ,[IdMoneda]
      ,[IdPersona]
      ,[Importe]
      ,[IdPropietario]
      ,[ImpactoEnSaldo]
      ,[IdEstado]
  FROM [orden_owner].[MovimientosSaldo] as s
where s.IdPropietario = @idPropietario

 
END  
