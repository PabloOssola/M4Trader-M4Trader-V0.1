CREATE TABLE [shared_owner].[CustomizacionUsuario]
(
	[IdCustomizacionUsuario] INT       CONSTRAINT [DF_CustomizacionUsuario_IdCustomizacionUsuario] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_CustomizacionUsuario]) NOT NULL,
    [IdUsuario]              INT       NOT NULL,
    [Codigo]                 VARCHAR (50) NOT NULL,
    [Valor]                  TEXT             NULL,
    CONSTRAINT [PK_configuracionesusuarioweb] PRIMARY KEY CLUSTERED ([IdCustomizacionUsuario] ASC) WITH (FILLFACTOR = 90),
	CONSTRAINT [FK_ConfiguracionesUsuarioWeb_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
);
