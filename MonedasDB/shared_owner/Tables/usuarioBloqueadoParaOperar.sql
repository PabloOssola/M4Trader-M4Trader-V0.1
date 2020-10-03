CREATE TABLE [shared_owner].[UsuarioBloqueadoParaOperar] (
    [IdUsuarioBloqueadoParaOperar]	INT			CONSTRAINT [DF_UsuarioBloqueadoParaOperar_IdUsuarioBloqueadoParaOperar] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_UsuarioBloqueadoParaOperar]) NOT NULL,
	[IdPersona]						INT			NOT NULL,
	[TipoOperacion]					CHAR		NOT NULL,
	[FechaBloqueadoDesde]			DATETIME	NOT NULL,
	[FechaBloqueadoHasta]			DATETIME	NOT NULL, 
    CONSTRAINT [PK_UsuarioBloqueadoParaOperar] PRIMARY KEY CLUSTERED ([IdUsuarioBloqueadoParaOperar] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_UsuarioBloqueadoParaOperar_Persona] FOREIGN KEY ([IdPersona]) REFERENCES [shared_owner].[parties] ([IdParty])
);


