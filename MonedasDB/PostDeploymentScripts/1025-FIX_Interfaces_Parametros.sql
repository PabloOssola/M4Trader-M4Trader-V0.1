-- 'mae.fix.poll.Fix.MaeOrderSenderClient
UPDATE [fix_owner].[ConfiguracionInterfaces]
SET
Parametros = '{"SocketConnectHost":"172.16.1.5", "SocketConnectPort":"10025", "SenderCompId":"FIXTest4", "TargetCompId":"FIXServer"}'
WHERE ClaseProcesa = 'mae.fix.poll.Fix.MaeOrderSenderClient'
print 'MaeOrderSenderClient parametros actualizados'

-- 'mae.fix.poll.Fix.MaePreciosProcesarMensaje
UPDATE [fix_owner].[ConfiguracionInterfaces]
SET
Parametros = '{"SocketConnectHost":"172.16.1.5", "SocketConnectPort":"8025", "SenderCompId":"CLIENTTEST3", "TargetCompId":"MAEFIXMDFServer"}'
WHERE ClaseProcesa = 'mae.fix.poll.Fix.MaePreciosProcesarMensaje'
print 'MaePreciosProcesarMensaje parametros actualizados'

-- 'mae.fix.byma.BymaWebServicePriceSender,mae.fix.byma
UPDATE [fix_owner].[ConfiguracionInterfaces]
SET
Parametros = ' {"SocketConnectHost":"127.0.0.1", "SocketConnectPort":"10442", "SenderCompId":"MAE1", "TargetCompId":"STUN", "SenderSubId":"tmae_01", "Password":"6m3r1c6"}'
WHERE ClaseProcesa = 'mae.fix.byma.BymaWebServicePriceSender,mae.fix.byma'
print 'BymaWebServicePriceSender parametros actualizados'











