CREATE PROCEDURE orden_owner.SAL_OBTENERSALDOSPORPERSONA  
@IdPersona int
AS  
BEGIN  

select 
	p.MarketCustomerNumber as Codigo, 
	p.Name as NombreUsuario, 
	m.descripcion as Moneda, 
	s.Importe as SaldoDisponible, 
	s.SaldoPendienteAcreditacion as MontoPendienteDeAcreditacion
from orden_owner.saldos as s
inner join shared_owner.parties as p on p.idparty = s.idpersona
inner join shared_owner.monedas as m on s.idmoneda = m.idmoneda
where s.idPersona = @IdPersona

 
END  
