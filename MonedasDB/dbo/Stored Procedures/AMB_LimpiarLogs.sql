CREATE PROCEDURE [dbo].[AMB_LimpiarLogs]
AS
BEGIN

TRUNCATE TABLE [api_owner].[LogCommand]
--TRUNCATE TABLE [fix_owner].[LogCommand]
--TRUNCATE TABLE [fix_owner].[LogProcesos]
--TRUNCATE TABLE [fix_owner].[LogSeguridad]
--TRUNCATE TABLE [fix_owner].[LogSqlErrores]
--TRUNCATE TABLE [fix_owner].[LogToOrderRouter]

--TRUNCATE TABLE [fix_owner].[MensajesEnviadosMarketData]
--TRUNCATE TABLE [fix_owner].[MensajesEnviadosOrdenes]
--TRUNCATE TABLE [fix_owner].[MensajesRecibidosMarketData]
--TRUNCATE TABLE [fix_owner].[MensajesRecibidosOrdenes]


TRUNCATE TABLE [orden_owner].[LogBitacoraOrdenes]
TRUNCATE TABLE [orden_owner].[LogCommand]
TRUNCATE TABLE [orden_owner].[LogProcesos]
TRUNCATE TABLE [orden_owner].[LogSeguridad]
TRUNCATE TABLE [orden_owner].[LogSqlErrores]

END