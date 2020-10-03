CREATE PROCEDURE [orden_owner].[QRY_SCRN_MOVIMIENTOSBYOPERACION]
	@IdOperacion INT=NULL ,
	@IdUsuario INT=NULL   
AS
BEGIN
  	
select 
		
		ms.Importe, 
		tm.Descripcion as TipoMovimiento, 
		tm.Codigo,
		p2.Name, 
		m1.Descripcion as Moneda,
		m1.codigo as CodigoMoneda,
		COUNT(1) OVER() AS TotalRows 
from  orden_owner.MovimientosSaldo as ms  
inner join shared_owner.TiposMovimiento as tm on ms.IdTipoMovimiento = tm.IdTipoMovimiento 
INNER JOIN shared_owner.parties as p2 on p2.idparty = ms.IdPersona 
INNER JOIN shared_owner.monedas as m1 on ms.idmoneda = m1.idmoneda
WHERE ms.IdPropietario = @IdOperacion and ms.idtipomovimiento in (1,2) and ms.IdPersona  in (select idpersona from shared_owner.usuarios where idusuario = @IdUsuario ) 
     ORDER BY ms.IdMovimiento DESC      
 
END