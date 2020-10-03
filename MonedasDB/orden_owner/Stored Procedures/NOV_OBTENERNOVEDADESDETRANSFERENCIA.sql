CREATE PROCEDURE orden_owner.NOV_OBTENERNOVEDADESDETRANSFERENCIA  
@IdPersona int = null,
@fechaDesde datetime = null,
@fechaHasta datetime = null,
@idMoneda tinyint = null,
@idEstado int = null,
@receptor nvarchar(22) = null,
@orden varchar(3) = null

AS  
BEGIN  

select n.fecha as Fecha, m.descripcion as DescripcionMoneda, n.Importe as Importe, e.Descripcion as Estado,  p.Name as Receptor
from orden_owner.NovedadesDeTransferencias as n
inner join shared_owner.monedas as m on n.idmoneda = m.idmoneda
inner join shared_owner.EstadosMovimientos as e on e.idestado = n.idestado
inner join shared_owner.parties as p on p.CBU = n.CBUDestino
inner join shared_owner.parties as p2 on p2.CBU = n.CBUOrigen
where p2.IdParty = @IdPersona
AND (@fechaDesde is null or @fechaDesde <= n.Fecha) 
AND (@fechaHasta is null or @fechaHasta >= n.Fecha) 
AND (@idMoneda is null or @idMoneda = n.IdMoneda) 
AND (@idEstado is null or @idEstado = n.IdEstado) 
AND (@receptor is null or @receptor = n.CBUDestino) 
order by case when @orden = 'asc' then 'ASC' ELSE 'DESC'  END
 
END  
