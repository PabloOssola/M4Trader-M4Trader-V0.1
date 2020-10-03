CREATE TABLE [shared_owner].[UsuariosLimitesDiarios] (
    [IdUsuarioLimiteDiario]			INT			CONSTRAINT [DF_UsuariosLimitesDiarios_IdUsuarioLimite] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_UsuariosLimitesDiarios]) NOT NULL,
	[IdUsuario]						INT			NOT NULL,
	[ConsumidoOferta]				DECIMAL		DEFAULT ((0)) NOT NULL,
	[ConsumidoOperacion]			DECIMAL		DEFAULT ((0)) NOT NULL,
	[Fecha]							DATETIME	NOT NULL,
	[Timestamp]					  TIMESTAMP		   NOT NULL,
    CONSTRAINT [PK_UsuariosLimitesDiarios] PRIMARY KEY CLUSTERED ([IdUsuarioLimiteDiario] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_UsuariosLimitesDiarios_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
);


