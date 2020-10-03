CREATE TABLE [orden_owner].[ChatUsuarios](
	[IdChatUsuario]		INT CONSTRAINT [DF__ChatUsuarios__IdChatUsuario] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_ChatUsuarios]) NOT NULL,
	[IdChat]                INT NOT NULL,
	[IdUsuario]             INT NOT NULL,
	[Fecha]					DATETIME NOT NULL,
    [EsOwner]				BIT            CONSTRAINT [DF__ChatUsuarios__EsOwner] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ChatUsuarios] PRIMARY KEY CLUSTERED([IdChatUsuario] ASC),
	CONSTRAINT [FK_ChatUsuarios_Chat] FOREIGN KEY ([IdChat]) REFERENCES [orden_owner].[Chats] ([IdChat]),
	CONSTRAINT [FK_ChatUsuarios_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
)
GO
