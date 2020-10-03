CREATE TABLE [orden_owner].[ConfiguracionSistemaUrls] (
	[IdConfiguracionSistemaUrls]				TINYINT CONSTRAINT [DF__ConfiguracionSistemaUrls__IdConfiguracionSistemaUrls]  DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_ConfiguracionSistemaUrls]) NOT NULL,
    [IdConfiguracionSistema]					TINYINT NOT NULL,
	[Url]										VARCHAR (255) NOT NULL,
	[TipoUrl]									VARCHAR (50) NOT NULL,
	[Usuario]									VARCHAR (50) NULL,
	[Password]									VARCHAR (50) NULL,
	[Parametros]								VARCHAR (1000) NULL,
    CONSTRAINT [PK_ConfiguracionSistemaUrls] PRIMARY KEY CLUSTERED ([IdConfiguracionSistemaUrls] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_ConfiguracionSistemaUrls_ConfiguracionSistema] FOREIGN KEY ([IdConfiguracionSistema]) REFERENCES [shared_owner].[ConfiguracionSistema] ([IdConfiguracionSistema])
);

