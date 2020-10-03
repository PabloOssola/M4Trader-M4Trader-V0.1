CREATE PROCEDURE [orden_owner].[QRY_SCRN_OPERACIONESBYAGENCIA]
	@IdUsuarioAgencia INT=NULL,
	@PageNumber bigint=NULL,     
    @PageSize bigint=0  
AS
BEGIN
 ;WITH pg AS (	
select 
		o.idoperacion, 
		o.NroOperacion, 
		o.FechaOperacion,
		o.Cantidad,
		o.Monto,
		o.Precio,
		p1.Name as PersonaCompradora, 
		p2.Name PersonaVendedora, 
		m1.CodigoISO CodigoMonedaCompra, 
		m1.Descripcion DescripcionMonedaCompra, 
		m2.CodigoISO CodigoMonedaVenta, 
		m2.Descripcion DescripcionMonedaVenta 
from 
		orden_owner.operaciones as o
INNER JOIN shared_owner.parties as p1 on p1.idparty = o.IdPersonaComprador
INNER JOIN shared_owner.parties as p2 on p2.idparty = o.IdPersonaVendedor
INNER JOIN shared_owner.monedas as m1 on o.idmonedacompra = m1.idmoneda
INNER JOIN shared_owner.monedas as m2 on o.idmonedaventa = m2.idmoneda
INNER JOIN shared_owner.usuarios as u on u.idpersona = p1.idparty 
inner join shared_owner.PartiesHierarchy as ph on o.idpersonacomprador = ph.idpartySon 
WHERE ph.IdPartyFather = (select TOP 1 idpersona from shared_owner.usuarios where idusuario = @IdUsuarioAgencia )
     ORDER BY o.FechaOperacion ASC  
	 OFFSET @PageSize * (@PageNumber - 1) ROWS    
     FETCH NEXT @PageSize ROWS ONLY    
)        

SELECT pg.* FROM pg;   

END