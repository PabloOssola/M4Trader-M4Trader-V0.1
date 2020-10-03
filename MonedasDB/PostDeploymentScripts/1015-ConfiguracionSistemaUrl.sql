IF NOT EXISTS (SELECT 1 FROM orden_owner.ConfiguracionSistemaUrls WHERE IdConfiguracionSistemaUrls = 2)
BEGIN
	INSERT INTO [orden_owner].[ConfiguracionSistemaUrls]
           ([IdConfiguracionSistemaUrls]
            ,[IdConfiguracionSistema]
			,[Url]
			,[TipoUrl]
			,[Usuario]
			,[Password]
			,[Parametros])
     VALUES
           (2
           ,1
           ,'http://localhost:21555/mae.fix.client.pool/Services/OrdenesService.svc/Rest'
           ,'OrdenesFIX'
           ,''
           ,''
		   ,'')
	PRINT 'Insert ID 2'
END
