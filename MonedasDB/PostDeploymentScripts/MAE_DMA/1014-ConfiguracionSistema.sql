DECLARE @IdMercado TINYINT
DECLARE @Sistema_PathSalida VARCHAR(1000)
DECLARE @Sistema_ServiceURL VARCHAR(1000)
DECLARE @Sistema_PortWCF INT
DECLARE @HostName VARCHAR(100)
DECLARE @virtualDirectory VARCHAR(100)

DECLARE @Configuracion_URL VARCHAR(1000)
DECLARE @Configuracion_Usuario VARCHAR(1000)
DECLARE @Configuracion_Pwd VARCHAR(1000)

DECLARE @Parametros_EnviaOrden_Host_MAE VARCHAR(1000)
DECLARE @Parametros_EnviaOrden_Port_MAE VARCHAR(1000)
DECLARE @Parametros_EnviaOrden_Sender_MAE VARCHAR(1000)
DECLARE @Parametros_EnviaOrden_Target_MAE VARCHAR(1000)
DECLARE @Parametros_EnvioOrden_Rueda_MAE VARCHAR(1000)
DECLARE @Parametros_EnvioOrden_Password_MAE VARCHAR (1000)
DECLARE @Parametros_EnvioOrden_UserName_MAE VARCHAR (1000)

DECLARE @Parametros_RecibeOrden_FIX VARCHAR(1000)

DECLARE @Parametros_MarketData_Host_MAE VARCHAR(1000)
DECLARE @Parametros_MarketData_Port_MAE VARCHAR(1000)
DECLARE @Parametros_MarketData_Sender_MAE VARCHAR(1000)
DECLARE @Parametros_MarketData_Target_MAE VARCHAR(1000)
DECLARE @Parametros_MarketData_Rueda_MAE VARCHAR(1000)
DECLARE @Parametros_MarketData_Password_MAE VARCHAR (1000)
DECLARE @Parametros_MarketData_UserName_MAE VARCHAR (1000)

SET @HostName = 'localhost'
SET @virtualDirectory = '/mae.ordenes.mvc'

SET @Sistema_PathSalida = 'C:\\MC_HOMO_500_MAE_PRD\\app\\salidas'
SET @Sistema_ServiceURL = 'DESA_100_MAE_1/services'
SET @Sistema_PortWCF = 21456

SET @Configuracion_URL = 'https://' + @HOSTNAME + @virtualDirectory + '/Services/MarketDataService.svc'
SET @Configuracion_Usuario = 'Precios'
SET @Configuracion_Pwd = 'pass'

SET @Parametros_EnviaOrden_Host_MAE = '172.16.1.5'
SET @Parametros_EnviaOrden_Port_MAE = '10031'
SET @Parametros_EnviaOrden_Sender_MAE = 'MAEFIXSORClient1'
SET @Parametros_EnviaOrden_Target_MAE ='MAEFIXSORServer'
SET @Parametros_EnvioOrden_Rueda_MAE = 'ONTI'
SET @Parametros_EnvioOrden_Password_MAE = 'phJ6Ag^6kzN3aMG5'
SET @Parametros_EnvioOrden_UserName_MAE = 'FIXSORClient1'

SET @Parametros_RecibeOrden_FIX = 'https://' + @HOSTNAME + @virtualDirectory + '/Services/OrdenService.svc/rest'

SET @Parametros_MarketData_Host_MAE = '172.16.1.5'
SET @Parametros_MarketData_Port_MAE = '10026'
SET @Parametros_MarketData_Sender_MAE = 'MAEFIXMDFClient1'
SET @Parametros_MarketData_Target_MAE = 'MAEFIXMDFServer'
SET @Parametros_MarketData_Rueda_MAE = 'ONTI'
SET @Parametros_MarketData_Password_MAE = 'XRd+dXQ73Vq_NJ9R'
SET @Parametros_MarketData_UserName_MAE = 'FIXMDFClient1'

IF NOT EXISTS (SELECT 1 FROM shared_owner.ConfiguracionSistema WHERE IdConfiguracionSistema = 1)
BEGIN
	INSERT INTO [shared_owner].[ConfiguracionSistema]
           ([IdConfiguracionSistema]
           ,[OcultarErroresBaseDeDatos]
           ,[PathSalida]
           ,[TiempoLogSQL]
           ,[PermiteProcesamientoParalelo]
           ,[EnviaNotificaciones]
		   ,[PreciosHabilitados]
		   ,[EnvioOrdenesHabilitados]
		   ,[MainPortWcfServices]
		   ,[AbsoluteServicesURL]
		   ,[EnviarAgentCode]
		   ,[ApiServicePort]
		   ,[JwtSecretKey]
		   ,[JwtAudienceToken]
		   ,[JwtIssuerToken]
		   ,[MaxOperationRows]
		   ,[MinOperationRows])
     VALUES
           (1
           ,1
           ,@Sistema_PathSalida
           ,5000
           ,0
           ,0
		   ,1
		   ,1
		   ,@Sistema_PortWCF
		   ,@Sistema_ServiceURL
		   ,1
		   ,15478
		   ,'clave-secreta-api'
		   ,'NacionalCampeon'
		   ,'UruguayCampeon'
		   ,10
		   ,2)
	PRINT 'Insert ID 1'
END

----------------------Mercado MAE
SELECT @IdMercado = IdMercado FROM shared_owner.Mercados WHERE Codigo = 'MAE'															
IF NOT EXISTS (SELECT 1 FROM fix_owner.ConfiguracionInterfaces WHERE ClaseProcesa = 'mae.fix.client.pool.Fix.Orders.FixOrderMaeClient')
BEGIN
	INSERT INTO [fix_owner].[ConfiguracionInterfaces]
           ([IdMercado]
           ,[Habilitado]
		   ,[InterfazServicio]
           ,[ClaseProcesa]
		   ,[HaciaMercado]
		   ,[Parametros]
		   )
     VALUES
           (@IdMercado
           ,1
		   ,'Ordenes'
           ,'mae.fix.client.pool.Fix.Orders.FixOrderMaeClient'
		   ,1
		   ,'{"SocketConnectHost":"'+ @Parametros_EnviaOrden_Host_MAE +'", "SocketConnectPort":"'+@Parametros_EnviaOrden_Port_MAE +'", "SenderCompId":"'+ @Parametros_EnviaOrden_Sender_MAE +'", "TargetCompId":"'+@Parametros_EnviaOrden_Target_MAE+'","Rueda":"'+@Parametros_EnvioOrden_Rueda_MAE+'", "UserName":"' + @Parametros_EnvioOrden_UserName_MAE + '", "Password":"' + @Parametros_EnvioOrden_Password_MAE + '", "ConfigInitiator":"INIT_ORD_MAE.cfg", "RutasArchivosBorrar":"FIX50 Sessions", "AppDataDictionary":".\\app\\FIX50SP2.org.xml", "DefaultApplVerID":"FIX.5.0SP2", "UsarSSL":"true", "SuscribirTodosProductosDeRueda":"false","CantidadProductosPorMensajeSuscripcion":"0"}'
)

	PRINT 'Insert ID 1'
END

IF NOT EXISTS (SELECT 1 FROM fix_owner.ConfiguracionInterfaces WHERE ClaseProcesa = 'mae.fix.client.pool.Fix.Orders.OrderRestServiceSender')
BEGIN
	INSERT INTO [fix_owner].[ConfiguracionInterfaces]
           ([IdMercado]
           ,[Habilitado]
		   ,[InterfazServicio]
           ,[ClaseProcesa]
		   ,[HaciaMercado]
		   ,[Parametros]
)
     VALUES
           (@IdMercado
           ,1
		   ,'Ordenes'
           ,'mae.fix.client.pool.Fix.Orders.OrderRestServiceSender'
		   ,0
		   ,@Parametros_RecibeOrden_FIX
		   )
	PRINT 'Insert ID 2'
END


IF NOT EXISTS (SELECT 1 FROM fix_owner.ConfiguracionInterfaces WHERE ClaseProcesa = 'mae.fix.client.pool.Fix.MarketDatas.FixMarketDataMAEClient')
BEGIN
	INSERT INTO [fix_owner].[ConfiguracionInterfaces]
           ([IdMercado]
           ,[Habilitado]
		   ,[InterfazServicio]
           ,[ClaseProcesa]
		   ,[HaciaMercado]
		   ,[Parametros]
)
     VALUES
           (@IdMercado
           ,1
		   ,'MarketData'
           ,'mae.fix.client.pool.Fix.MarketDatas.FixMarketDataMAEClient'
		   ,1
		   ,'{"SocketConnectHost":"'+@Parametros_MarketData_Host_MAE+'", "SocketConnectPort":"'+@Parametros_MarketData_Port_MAE+'", "SenderCompId":"'+@Parametros_MarketData_Sender_MAE+'", "TargetCompId":"'+@Parametros_MarketData_Target_MAE+'","Rueda":"'+@Parametros_MarketData_Rueda_MAE+'", "UserName":"' + @Parametros_MarketData_UserName_MAE + '", "Password":"' + @Parametros_MarketData_Password_MAE + '", "ConfigInitiator":"INIT_MD_MAE.cfg", "RutasArchivosBorrar":"FIX50SP2 Sessions", "AppDataDictionary":".\\app\\FIX50SP2.org.xml", "DefaultApplVerID":"FIX.5.0SP2", "MarketDepth":"5", "UsarSecurityList": "true", "UsarSSL":"true", "SuscribirTodosProductosDeRueda":"false","CantidadProductosPorMensajeSuscripcion":"0"}'
)
	PRINT 'Insert ID 3'
END


IF NOT EXISTS (SELECT 1 FROM fix_owner.ConfiguracionInterfaces WHERE ClaseProcesa = 'mae.fix.client.pool.Fix.MarketDatas.MarketDataRestServiceSender')
BEGIN
	INSERT INTO [fix_owner].[ConfiguracionInterfaces]
           ([IdMercado]
           ,[Habilitado]
		   ,[InterfazServicio]
           ,[ClaseProcesa]
		   ,[HaciaMercado]
		   ,[Parametros]
)
     VALUES
           (@IdMercado
           ,1
		   ,'MarketData'
           ,'mae.fix.client.pool.Fix.MarketDatas.MarketDataRestServiceSender'
		   ,0
		   ,'https://' + @HOSTNAME + @virtualDirectory + '/Services/MarketDataService.svc/Rest'
		   )
	PRINT 'Insert ID 4'
END

IF NOT EXISTS (SELECT 1 FROM fix_owner.ConfiguracionInterfaces WHERE ClaseProcesa = 'mae.fix.client.pool.Fix.MarketDatas.MarketDataNetPipeSender')
BEGIN
	INSERT INTO [fix_owner].[ConfiguracionInterfaces]
           ([IdMercado]
           ,[Habilitado]
		   ,[InterfazServicio]
           ,[ClaseProcesa]
		   ,[HaciaMercado]
		   ,[Parametros]
)
     VALUES
           (@IdMercado
           ,0
		   ,'MarketData'
           ,'mae.fix.client.pool.Fix.MarketDatas.MarketDataNetPipeSender'
		   ,0
		   ,'net.pipe://' + @HOSTNAME + @virtualDirectory + '/Services/MarketDataService.svc/netpipe'
)
	PRINT 'Insert ID 5'
END

IF NOT EXISTS (SELECT 1 FROM fix_owner.ConfiguracionInterfaces WHERE ClaseProcesa = 'mae.fix.client.pool.Fix.SecurityLists.SecurityListRestServiceSender' AND IdMercado = @IdMercado)
BEGIN
	INSERT INTO [fix_owner].[ConfiguracionInterfaces]
           ([IdMercado]
           ,[Habilitado]
		   ,[InterfazServicio]
           ,[ClaseProcesa]
		   ,[HaciaMercado]
		   ,[Parametros]
		   )
     VALUES
           (@IdMercado
           ,1
		   ,'SecurityList'
           ,'mae.fix.client.pool.Fix.SecurityLists.SecurityListRestServiceSender'
		   ,0
		   ,'https://' + @HOSTNAME + @virtualDirectory + '/Services/MarketDataService.svc/Rest'
		   )
	PRINT 'Insert ID 6'

END

IF NOT EXISTS (SELECT 1 FROM fix_owner.ConfiguracionInterfaces WHERE ClaseProcesa = 'mae.fix.client.pool.Fix.MarketDatas.MarketDataApiServiceSender' AND IdMercado = @IdMercado)
BEGIN
	INSERT INTO [fix_owner].[ConfiguracionInterfaces]
           ([IdMercado]
           ,[Habilitado]
		   ,[InterfazServicio]
           ,[ClaseProcesa]
		   ,[HaciaMercado]
		   ,[Parametros]
		   )
     VALUES
           (@IdMercado
           ,1
		   ,'MarketData'
           ,'mae.fix.client.pool.Fix.SecurityLists.SecurityListRestServiceSender'
		   ,0
		   ,'http://marketdataapp-api.azurewebsites.net/api/marketdata/'
		   )
	PRINT 'Insert ID 7'
END

