
IF (1 > (SELECT COUNT(1) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'orden_owner' AND TABLE_NAME='Ordenes' AND COLUMN_NAME = 'IdUsuario'))
BEGIN
	ALTER TABLE orden_owner.Ordenes ADD [IdUsuario] INT NULL
	PRINT 'orden_owner.Ordenes.IdUsuario'

END

go
UPDATE o 
SET o.IdUsuario = (
select top 1 idusuario from shared_owner.Usuarios u
where IdPersona = o.IdPersona)
from orden_owner.Ordenes o
where IdUsuario is null

