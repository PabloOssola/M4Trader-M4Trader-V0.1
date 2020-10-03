ALTER SCHEMA shared_owner TRANSFER fix_owner.RuedasBySecurityList
GO
UPDATE shared_owner.LogAuditoriaClases SET NombreEntidad = 'ConfirmacionManual' WHERE NombreEntidad = 'ConfirmacionAutomatica'
EXEC sp_rename 'orden_owner.ConfirmacionAutomatica', ConfirmacionManual
EXEC sp_rename 'orden_owner.ConfirmacionManual.IdConfirmacionAutomatica', 'IdConfirmacionManual', 'COLUMN'
UPDATE shared_owner.Acciones SET Descripcion = 'ConfirmacionManual' WHERE IdAccion = 36
DELETE orden_owner.ConfirmacionManual
GO
ALTER SCHEMA shared_owner TRANSFER fix_owner.SecurityList
GO
UPDATE shared_owner.MensajesLiterales
SET Valor = 'Bid'
where Referencia = 'TRADE_TYPES.BUY'



UPDATE shared_owner.MensajesLiterales
SET Valor = 'Offer'
where Referencia = 'TRADE_TYPES.SELL'


ALTER TABLE [orden_owner].[Ofertas] ALTER COLUMN Valorizacion DECIMAL(24,8) NULL
ALTER TABLE [orden_owner].[Ordenes] ALTER COLUMN Valorizacion DECIMAL(24,8) NULL
ALTER TABLE [orden_owner].[OrdenOperacion] ALTER COLUMN Valorizacion DECIMAL(24,8) NULL
ALTER TABLE [orden_owner].[OperacionHistorico]  ALTER COLUMN Valorizacion DECIMAL(24,8) NULL


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
