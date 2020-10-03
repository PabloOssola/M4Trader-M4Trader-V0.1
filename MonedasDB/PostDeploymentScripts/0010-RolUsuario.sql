DECLARE @IdRol SMALLINT
DECLARE @IdUsuario INT

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 1
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'admin'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 1'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 2
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'admin'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 3
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'admin'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 3'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 1
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'UsuarioProceso'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert Acceso al sistema para UsuarioProceso'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 6
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'UsuarioProceso'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert Acceso al sistema para UsuarioProceso'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 7
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'UsuarioProceso'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert Acceso al sistema para UsuarioProceso'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 1
insert into shared_owner.RolUsuario(IdUsuario, IdRol)
select idusuario, @IdRol from shared_owner.Usuarios u
inner join shared_owner.Parties p on p.IdParty = u.IdPersona
where not exists (select * from  shared_owner.RolUsuario where IdUsuario = u.IdUsuario and IdRol = @IdRol)
and p.PartyType = (select IdTipoPersona from  shared_owner.TiposPersona
where Descripcion = 'NEGOCIADOR')

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 2
insert into shared_owner.RolUsuario(IdUsuario, IdRol)
select idusuario, @IdRol from shared_owner.Usuarios u
inner join shared_owner.Parties p on p.IdParty = u.IdPersona
where not exists (select * from  shared_owner.RolUsuario where IdUsuario = u.IdUsuario and IdRol = @IdRol)
and p.PartyType = (select IdTipoPersona from  shared_owner.TiposPersona
where Descripcion = 'NEGOCIADOR')

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 9
insert into shared_owner.RolUsuario(IdUsuario, IdRol)
select idusuario, @IdRol from shared_owner.Usuarios u
inner join shared_owner.Parties p on p.IdParty = u.IdPersona
where not exists (select * from  shared_owner.RolUsuario where IdUsuario = u.IdUsuario and IdRol = @IdRol)
and p.PartyType = (select IdTipoPersona from  shared_owner.TiposPersona
where Descripcion = 'NEGOCIADOR')

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 10
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'admin'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 10'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 11
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'admin'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 11'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 1
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'AdminWebBBVA'
IF (@IdUsuario IS NOT NULL) AND NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 12'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 2
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'AdminWebBBVA'
IF (@IdUsuario IS NOT NULL) AND NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 13'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 9
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'AdminWebBBVA'
IF (@IdUsuario IS NOT NULL) AND NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 14'
END
