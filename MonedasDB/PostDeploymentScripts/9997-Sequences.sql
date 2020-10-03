--SECUENCIAS
DECLARE @NombreSequence varchar(1000)
DECLARE @NombreTabla varchar(1000)
DECLARE @NombreCampo varchar(1000)

/************************** FIX OWNER **************************************************/

SET @NombreSequence = 'fix_owner.SQ_ConfiguracionInterfaces'
SET @NombreTabla = 'fix_owner.ConfiguracionInterfaces'
SET @NombreCampo = 'IdConfiguracionInterfaz'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'fix_owner.SQ_LogCommand'
SET @NombreTabla = 'fix_owner.LogCommand'
SET @NombreCampo = 'IdLogCommand'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'fix_owner.SQ_LogProcesos'
SET @NombreTabla = 'fix_owner.LogProcesos'
SET @NombreCampo = 'IdLogProceso'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'fix_owner.SQ_LogSeguridad'
SET @NombreTabla = 'fix_owner.LogSeguridad'
SET @NombreCampo = 'IdLogSeguridad'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'fix_owner.SQ_LogSqlErrores'
SET @NombreTabla = 'fix_owner.LogSqlErrores'
SET @NombreCampo = 'IdLogSqlErrores'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'fix_owner.SQ_MensajesEnviadosMarketData'
SET @NombreTabla = 'fix_owner.MensajesEnviadosMarketData'
SET @NombreCampo = 'IdMensajeEnviadoMarketData'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'fix_owner.SQ_MensajesEnviadosOrdenes'
SET @NombreTabla = 'fix_owner.MensajesEnviadosOrdenes'
SET @NombreCampo = 'IdMensajeEnviadoOrdenes'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'fix_owner.SQ_MensajesRecibidosMarketData'
SET @NombreTabla = 'fix_owner.MensajesRecibidosMarketData'
SET @NombreCampo = 'IdMensajeRecibidoMarketData'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'fix_owner.SQ_MensajesRecibidosOrdenes'
SET @NombreTabla = 'fix_owner.MensajesRecibidosOrdenes'
SET @NombreCampo = 'IdMensajeRecibidoOrdenes'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'fix_owner.SQ_OrdenesRelacionIds'
SET @NombreTabla = 'fix_owner.OrdenesRelacionIds'
SET @NombreCampo = 'IdOrdenRelacionId'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_SecurityList'
SET @NombreTabla = 'shared_owner.SecurityList'
SET @NombreCampo = 'IdSecurityList'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'fix_owner.SQ_TipoNegociacion'
SET @NombreTabla = 'fix_owner.TipoNegociacion'
SET @NombreCampo = 'IdTipoNegociacion'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

/************************** ORDEN OWNER **************************************************/

SET @NombreSequence = 'orden_owner.SQ_ConfiguracionSistemaUrls'
SET @NombreTabla = 'orden_owner.ConfiguracionSistemaUrls'
SET @NombreCampo = 'IdConfiguracionSistemaUrls'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_ConfirmacionManual'
SET @NombreTabla = 'orden_owner.ConfirmacionManual'
SET @NombreCampo = 'IdConfirmacionManual'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_DailyHistoricalPrice'
SET @NombreTabla = 'orden_owner.DailyHistoricalPrice'
SET @NombreCampo = 'IdDailyHistoricalPrice'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_EstadosOrden'
SET @NombreTabla = 'orden_owner.EstadosOrden'
SET @NombreCampo = 'IdEstadoOrden'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_LogBitacoraOrdenes'
SET @NombreTabla = 'orden_owner.LogBitacoraOrdenes'
SET @NombreCampo = 'IdLogBitacoraOrden'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_LogCommand'
SET @NombreTabla = 'orden_owner.LogCommand'
SET @NombreCampo = 'IdLogCommand'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'api_owner.SQ_LogCommand'
SET @NombreTabla = 'api_owner.LogCommand'
SET @NombreCampo = 'IdLogCommand'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_LogProcesos'
SET @NombreTabla = 'orden_owner.LogProcesos'
SET @NombreCampo = 'IdLogProceso'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_LogSeguridad'
SET @NombreTabla = 'orden_owner.LogSeguridad'
SET @NombreCampo = 'IdLogSeguridad'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_LogSqlErrores'
SET @NombreTabla = 'orden_owner.LogSqlErrores'
SET @NombreCampo = 'IdLogSqlErrores'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_Noticias'
SET @NombreTabla = 'orden_owner.Noticias'
SET @NombreCampo = 'IdNoticia'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_Ofertas'
SET @NombreTabla = 'orden_owner.Ofertas'
SET @NombreCampo = 'IdOferta'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_Ordenes_NumeroOrdenInterno'
SET @NombreTabla = 'orden_owner.Ordenes'
SET @NombreCampo = 'NumeroOrdenInterno'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_Ordenes'
SET @NombreTabla = 'orden_owner.Ordenes'
SET @NombreCampo = 'IdOrden'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_OrdenOperacion'
SET @NombreTabla = 'orden_owner.OrdenOperacion'
SET @NombreCampo = 'IdOrdenOperacion'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_Portfolios'
SET @NombreTabla = 'orden_owner.Portfolios'
SET @NombreCampo = 'IdPortfolio'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_PortfoliosComposicion'
SET @NombreTabla = 'orden_owner.PortfoliosComposicion'
SET @NombreCampo = 'IdPortfoliosComposicion'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_PortfoliosUsuario'
SET @NombreTabla = 'orden_owner.PortfolioUsuario'
SET @NombreCampo = 'IdPortfolioUsuario'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_Precios'
SET @NombreTabla = 'orden_owner.Precios'
SET @NombreCampo = 'IdPrecio'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_PreciosHistoricos'
SET @NombreTabla = 'orden_owner.PreciosHistoricos'
SET @NombreCampo = 'IdPrecioHistorico'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_Productos'
SET @NombreTabla = 'orden_owner.Productos'
SET @NombreCampo = 'IdProducto'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_TiposOrden'
SET @NombreTabla = 'orden_owner.TiposOrden'
SET @NombreCampo = 'IdTipoOrden'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_ProductosPorMercado'
SET @NombreTabla = 'orden_owner.ProductosPorMercados'
SET @NombreCampo = 'IdProductoPorMercado'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_Plazo'
SET @NombreTabla = 'orden_owner.Plazos'
SET @NombreCampo = 'IdPlazo'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_Saldo'
SET @NombreTabla = 'orden_owner.Saldos'
SET @NombreCampo = 'IdSaldo'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_Sources'
SET @NombreTabla = 'orden_owner.SourcesApplication'
SET @NombreCampo = 'IdSourceApplication'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_TiposCuenta'
SET @NombreTabla = 'orden_owner.TiposCuenta'
SET @NombreCampo = 'IdTipoCuenta'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_TiposProducto'
SET @NombreTabla = 'orden_owner.TiposProducto'
SET @NombreCampo = 'IdTipoProducto'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_ProductoPlazoFechaLiquidacion'
SET @NombreTabla = 'orden_owner.ProductoPlazoFechaLiquidacion'
SET @NombreCampo = 'IdProductoPlazoFechaLiquidacion'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo



/**************************** SHARED OWNER ****************************************/
SET @NombreSequence = 'shared_owner.SQ_Acciones'
SET @NombreTabla = 'shared_owner.Acciones'
SET @NombreCampo = 'IdAccion'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_AccionRol'
SET @NombreTabla = 'shared_owner.AccionRol'
SET @NombreCampo = 'IdAccionRol'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_ConfiguracionSeguridad'
SET @NombreTabla = 'shared_owner.ConfiguracionSeguridad'
SET @NombreCampo = 'IdConfiguracionSeguridad'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_ConfiguracionSistema'
SET @NombreTabla = 'shared_owner.ConfiguracionSistema'
SET @NombreCampo = 'IdConfiguracionSistema'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_CustomizacionUsuario'
SET @NombreTabla = 'shared_owner.CustomizacionUsuario'
SET @NombreCampo = 'IdCustomizacionUsuario'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_EstadoSistema'
SET @NombreTabla = 'shared_owner.EstadoSistema'
SET @NombreCampo = 'IdEstadoSistema'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_HistoricoPassword'
SET @NombreTabla = 'shared_owner.HistoricoPassword'
SET @NombreCampo = 'IdHistoricoPassword'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_LogAuditoria'
SET @NombreTabla = 'shared_owner.LogAuditoria'
SET @NombreCampo = 'IdLogAuditoria'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_MensajesLiterales'
SET @NombreTabla = 'shared_owner.MensajesLiterales'
SET @NombreCampo = 'IdMensajesLiterales'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_Mercados'
SET @NombreTabla = 'shared_owner.Mercados'
SET @NombreCampo = 'IdMercado'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_Monedas'
SET @NombreTabla = 'shared_owner.Monedas'
SET @NombreCampo = 'IdMoneda'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_MotivosBaja'
SET @NombreTabla = 'shared_owner.MotivosBaja'
SET @NombreCampo = 'IdMotivoBaja'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_Parties'
SET @NombreTabla = 'shared_owner.Parties'
SET @NombreCampo = 'IdParty'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_PartiesHierarchy'
SET @NombreTabla = 'shared_owner.PartiesHierarchy'
SET @NombreCampo = 'IdPartiesHierarchy'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_RechazoMercado'
SET @NombreTabla = 'shared_owner.RechazosMercado'
SET @NombreCampo = 'IdRechazoMercado'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_Roles'
SET @NombreTabla = 'shared_owner.Roles'
SET @NombreCampo = 'IdRol'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_RolUsuario'
SET @NombreTabla = 'shared_owner.RolUsuario'
SET @NombreCampo = 'IdRolUsuario'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_RuedasBySecurityList'
SET @NombreTabla = 'shared_owner.RuedasBySecurityList'
SET @NombreCampo = 'IdRuedaBySecurityList'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_SeguridadPermisos'
SET @NombreTabla = 'shared_owner.SeguridadPermisos'
SET @NombreCampo = 'IdSeguridadPermiso'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_TiposEjecucionMercado'
SET @NombreTabla = 'shared_owner.TiposEjecucionMercado'
SET @NombreCampo = 'IdTipoEjecucionMercado'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_TiposMoneda'
SET @NombreTabla = 'shared_owner.TiposMoneda'
SET @NombreCampo = 'IdTipoMoneda'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_TiposPersona'
SET @NombreTabla = 'shared_owner.TiposPersona'
SET @NombreCampo = 'IdTipoPersona'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_TiposVigencia'
SET @NombreTabla = 'shared_owner.TiposVigencia'
SET @NombreCampo = 'IdTipoVigencia'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_Usuarios'
SET @NombreTabla = 'shared_owner.Usuarios'
SET @NombreCampo = 'IdUsuario'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo



/**************************** PRECIOS OWNER ****************************************/
SET @NombreSequence = 'precios_owner.SQ_HistoricoCierresMes'
SET @NombreTabla = 'precios_owner.HistoricoCierresMes'
SET @NombreCampo = 'IdHistoricoCierresMes'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'precios_owner.SQ_HistoricoCierresSemana'
SET @NombreTabla = 'precios_owner.HistoricoCierresSemana'
SET @NombreCampo = 'IdHistoricoCierresSemana'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'precios_owner.SQ_HistoricoCierresDia'
SET @NombreTabla = 'precios_owner.HistoricoCierresDia'
SET @NombreCampo = 'IdHistoricoCierresDia'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'precios_owner.SQ_HistoricoCierres60Min'
SET @NombreTabla = 'precios_owner.HistoricoCierres60Min'
SET @NombreCampo = 'IdHistoricoCierres60Min'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'precios_owner.SQ_HistoricoCierres30Min'
SET @NombreTabla = 'precios_owner.HistoricoCierres30Min'
SET @NombreCampo = 'IdHistoricoCierres30Min'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'precios_owner.SQ_HistoricoOfertas20Min'
SET @NombreTabla = 'precios_owner.HistoricoOfertas20Min'
SET @NombreCampo = 'IdHistoricoOfertas20Min'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'precios_owner.SQ_CollateralReport'
SET @NombreTabla = 'precios_owner.CollateralReport'
SET @NombreCampo = 'IdCollateralReport'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_PermisosProductos'
SET @NombreTabla = 'shared_owner.PermisosProductos'
SET @NombreCampo = 'IdPermisosProductos'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_RuedaParty'
SET @NombreTabla = 'orden_owner.RuedaParty'
SET @NombreCampo = 'IdRuedaParty'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_UsuariosAdministradorParties'
SET @NombreTabla = 'shared_owner.UsuariosAdministradorParties'
SET @NombreCampo = 'IdAdministradorParty'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_UsuariosLimites'
SET @NombreTabla = 'shared_owner.UsuariosLimites'
SET @NombreCampo = 'IdUsuarioLimite'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'shared_owner.SQ_UsuariosLimitesDiarios'
SET @NombreTabla = 'shared_owner.UsuariosLimitesDiarios'
SET @NombreCampo = 'IdUsuarioLimiteDiario'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_LogConectividad'
SET @NombreTabla = 'orden_owner.LogConectividad'
SET @NombreCampo = 'IdLogConectividad'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_Chats'
SET @NombreTabla = 'orden_owner.Chats'
SET @NombreCampo = 'IdChat'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_ChatMensajes'
SET @NombreTabla = 'orden_owner.ChatMensajes'
SET @NombreCampo = 'IdChatMensaje'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_ChatMensajes'
SET @NombreTabla = 'orden_owner.ChatMensajes'
SET @NombreCampo = 'IdChatMensaje'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_ChatTipoMensaje'
SET @NombreTabla = 'orden_owner.ChatTiposMensaje'
SET @NombreCampo = 'IdChatTipoMensaje'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo

SET @NombreSequence = 'orden_owner.SQ_ChatUsuarios'
SET @NombreTabla = 'orden_owner.ChatUsuarios'
SET @NombreCampo = 'IdChatUsuario'
EXEC [dbo].[AMB_Sequence] @NombreSequence, @NombreTabla, @NombreCampo