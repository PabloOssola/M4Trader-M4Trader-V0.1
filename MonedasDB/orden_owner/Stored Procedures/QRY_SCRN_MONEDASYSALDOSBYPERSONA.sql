CREATE PROCEDURE [orden_owner].[QRY_SCRN_MONEDASYSALDOSBYPERSONA]
	@IdUsuario INT=NULL ,  
	@PageNumber bigint=NULL,     
    @PageSize bigint=0  
AS
BEGIN

;WITH pg AS ( 


select 
    m.codigo, 
    m.descripcion, 
    m.CodigoISO, 
    p.PrecioCompra,
    p.PrecioVenta, 
	(select s2.importe from [orden_owner].[saldos] as s2 where s2.idmoneda in (select idmoneda from shared_owner.monedas where esmonedanacional = 1) and s2.idpersona in (select idpersona from shared_owner.usuarios where idusuario = @IdUsuario ) ) SaldoCompra, 
    coalesce(s.Importe, 0.0000) SaldoVenta, 
    s.NumeroCuenta,
    CASE WHEN s.idpersona is null THEN 0 else 1 end as TieneSaldo 
from shared_owner.monedas as m 
LEFT JOIN  [orden_owner].[saldos]  as s  on m.Idmoneda = s.Idmoneda and s.idpersona in (select idpersona from shared_owner.usuarios where idusuario = @IdUsuario ) 
inner join [orden_owner].[Pizarra] as p on m.idmoneda = p.idmoneda 
where m.EsMonedaNacional = 0 
     ORDER BY m.idmoneda ASC     
     OFFSET @PageSize * (@PageNumber - 1) ROWS    
     FETCH NEXT @PageSize ROWS ONLY    
    )    
        
 SELECT pg.* FROM pg;  

END