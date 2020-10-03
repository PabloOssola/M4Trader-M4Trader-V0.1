IF NOT EXISTS (SELECT 1 FROM shared_owner.EstadoSistema)
BEGIN
	INSERT INTO shared_owner.EstadoSistema (FechaSistema, IdUsuarioApertura, BajaLogica, EstadoAbierto, EjecucionValidacion)
		VALUES ( CONVERT(DATETIME,CONVERT(varchar(10), GETDATE(), 103),103), (SELECT TOP 1 IdUsuario FROM shared_owner.Usuarios ORDER BY IdUsuario ASC), 0, 1, 0)
	PRINT 'Insert ID 1'
END
