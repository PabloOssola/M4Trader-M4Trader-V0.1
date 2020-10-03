CREATE PROCEDURE [dbo].[AMB_LimpiarDatos]
@BorrarProductosMercadosUsuariosPersonasRuedas BIT = 0
AS
BEGIN


TRUNCATE TABLE [orden_owner].[DailyHistoricalPrice]
TRUNCATE TABLE [orden_owner].[Ofertas]
DELETE FROM [orden_owner].[OrdenesHistorico]
TRUNCATE TABLE [orden_owner].[OrdenOperacionHistorico]
TRUNCATE TABLE [orden_owner].[OrdenOperacion]
DELETE FROM [orden_owner].[LogBitacoraOrdenes]
DELETE FROM [orden_owner].[Ordenes]
TRUNCATE TABLE [orden_owner].[PortfolioUsuario]
TRUNCATE TABLE [orden_owner].[PortfoliosComposicion]
DELETE FROM [orden_owner].[Portfolios]
TRUNCATE TABLE [orden_owner].[PreciosHistoricos]
TRUNCATE TABLE [orden_owner].[Precios]
TRUNCATE TABLE [orden_owner].[Saldos]
TRUNCATE TABLE [shared_owner].[HistoricoPassword]
TRUNCATE TABLE [shared_owner].[LogAuditoria]
TRUNCATE TABLE [shared_owner].[Sesiones]
TRUNCATE TABLE [shared_owner].[EstadoSistema]

IF (@BorrarProductosMercadosUsuariosPersonasRuedas = 1)
BEGIN
	--VER DE INSERTAR LUEGO
	TRUNCATE TABLE [orden_owner].[ProductosPorMercados]
	DELETE FROM [orden_owner].[Productos]
	DELETE [shared_owner].[RuedasBySecurityList]
	DELETE [shared_owner].[SecurityList]
	--TRUNCATE TABLE [fix_owner].[ConfiguracionInterfaces]
	DELETE FROM [shared_owner].[Mercados]
	DELETE FROM [shared_owner].[RolUsuario]
	DELETE FROM [shared_owner].[CustomizacionUsuario]
	DELETE FROM [shared_owner].[Usuarios]
	DELETE FROM [shared_owner].[PartiesHierarchy]
	DELETE FROM [shared_owner].[Parties]
END


END