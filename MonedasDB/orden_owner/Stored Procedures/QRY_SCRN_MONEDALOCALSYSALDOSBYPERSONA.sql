CREATE PROCEDURE [orden_owner].[QRY_SCRN_MONEDALOCALYSALDOSBYPERSONA]
	@IdUsuario INT=NULL 
AS
BEGIN




select 
    m.codigo, 
    m.descripcion, 
    m.CodigoISO, 
    s.Importe
from shared_owner.monedas as m 
LEFT JOIN  [orden_owner].[saldos]  as s  on m.Idmoneda = s.Idmoneda and s.idpersona in (select idpersona from shared_owner.usuarios where idusuario = @IdUsuario ) 
inner join [orden_owner].[Pizarra] as p on m.idmoneda = p.idmoneda 
where m.EsMonedaNacional = 1
   

END