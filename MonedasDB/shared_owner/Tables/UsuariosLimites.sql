CREATE TABLE [shared_owner].[UsuariosLimites] (
    [IdUsuarioLimite]			INT			CONSTRAINT [DF_UsuariosLimites_IdUsuarioLimite] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_UsuariosLimites]) NOT NULL,
	[IdUsuario]					INT			NOT NULL,
	[LimiteOferta]				DECIMAL		DEFAULT ((0)) NOT NULL,
	[LimiteOperacion]			DECIMAL		DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UsuariosLimites] PRIMARY KEY CLUSTERED ([IdUsuarioLimite] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_UsuariosLimites_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
);


