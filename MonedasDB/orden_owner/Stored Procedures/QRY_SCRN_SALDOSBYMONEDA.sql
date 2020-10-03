CREATE PROCEDURE [orden_owner].[QRY_SCRN_SALDOSBYMONEDA]
	@IdUsuario INT=NULL 
AS
BEGIN 
	select  
			s.idsaldo,
			p.Name NombrePersona, 
			S.NumeroCuenta as NumeroCuenta, 
			s.Importe as Saldo, 
			m.IdMoneda as IdMoneda, 
			m.codigo as Codigo, 
			m.CodigoISO as CodigoISO, 
			m.Descripcion as MonedaDescripcion, 
			s.SaldoPendienteAcreditacion as SaldoPendiente
	from orden_owner.saldos as s 
			INNER JOIN shared_owner.monedas as m on s.idmoneda = m.idmoneda
			INNER JOIN shared_owner.parties as p on p.idparty = s.idpersona
			INNER JOIN shared_owner.usuarios as u on u.idpersona = p.idparty
	where u.idusuario = @IdUsuario
 

END