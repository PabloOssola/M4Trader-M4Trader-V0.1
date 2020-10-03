CREATE TABLE [shared_owner].[ConfiguracionSistema] (
    [IdConfiguracionSistema]					TINYINT CONSTRAINT [DF__ConfiguracionSistema__IdConfiguracionSistema]  DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_ConfiguracionSistema]) NOT NULL,
	[OcultarErroresBaseDeDatos]					bit CONSTRAINT [DF__ConfiguracionSistema__OcultarErroresBaseDeDatos] DEFAULT ((1)) NOT NULL,
	[PathSalida]								varchar(max) CONSTRAINT [DF__ConfiguracionSistema__PathSalida] DEFAULT ('C:\') NOT NULL,
	[TiempoLogSQL]								int CONSTRAINT [DF__ConfiguracionSistema__TiempoLogSQL]  DEFAULT ((100000)) NOT NULL,
	[PermiteProcesamientoParalelo]				bit CONSTRAINT [DF__ConfiguracionSistema__PermiteProcesamientoParalelo]  DEFAULT ((0)) NOT NULL,
	[EnviaNotificaciones]						bit CONSTRAINT [DF__ConfiguracionSistema__EnviaNotificaciones]  DEFAULT ((0)) NOT NULL,
	[PreciosHabilitados]						bit CONSTRAINT [DF__ConfiguracionSistema__PreciosHabilitados]  DEFAULT ((1)) NOT NULL,
	[EnvioOrdenesHabilitados]					bit CONSTRAINT [DF__ConfiguracionSistema__EnvioOrdenesHabilitados]  DEFAULT ((1)) NOT NULL, 
    [MainPortWcfServices]						INT NOT NULL CONSTRAINT [DF__ConfiguracionSistema__MainPortWcfServices] DEFAULT 21456, 
    [AbsoluteServicesURL]						VARCHAR(50) NOT NULL CONSTRAINT [DF__ConfiguracionSistema__AbsoluteServicesURL] DEFAULT 'FIXC_DESA_100_MAE_1/services', 
	[EnviarAgentCode]							BIT CONSTRAINT [DF__ConfiguracionSistema__EnviarAgentCode]  DEFAULT ((1)) NOT NULL, 
    [ApiServicePort]							INT CONSTRAINT [DF__ConfiguracionSistema__ApiServicePort]  DEFAULT ((15478)) NOT NULL, 
    [JwtSecretKey]								VARCHAR(50) NOT NULL CONSTRAINT [DF__ConfiguracionSistema__JwtSecretKey] DEFAULT 'clave-secreta-api', 
	[JwtAudienceToken]							VARCHAR(200) NOT NULL CONSTRAINT [DF__ConfiguracionSistema__JwtAudienceToken] DEFAULT 'NacionalCampeon', 
	[JwtIssuerToken]							VARCHAR(200) NOT NULL CONSTRAINT [DF__ConfiguracionSistema__JwtIssuerToken] DEFAULT 'UruguayCampeon', 
    [MaxOperationRows]							TINYINT NOT NULL CONSTRAINT [DF__ConfiguracionSistema__MaxOperationRows] DEFAULT ((10)),  
    [MinOperationRows]							TINYINT NOT NULL CONSTRAINT [DF__ConfiguracionSistema__MinOperationRows] DEFAULT ((2)),  
    CONSTRAINT [PK_ConfiguracionSistema] PRIMARY KEY CLUSTERED ([IdConfiguracionSistema] ASC) WITH (FILLFACTOR = 90) ON [FG_Fix_001]
);

