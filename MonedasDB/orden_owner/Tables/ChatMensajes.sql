CREATE TABLE [orden_owner].[ChatMensajes](
	[IdChatMensaje]		    bigint CONSTRAINT [DF__ChatMensajes__IdChatMensaje] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_ChatMensajes]) NOT NULL,
	[IdChat]                INT NOT NULL,
	[IdUsuario]             INT NOT NULL,
	[Fecha]					DATETIME NOT NULL,
	[Mensaje]				VARCHAR(MAX) NOT NULL,
	[IdChatTipoMensaje]		TINYINT NOT NULL,
    CONSTRAINT [PK_ChatMensajes] PRIMARY KEY CLUSTERED([IdChatMensaje] ASC),
	CONSTRAINT [FK_ChatMensajes_Chat] FOREIGN KEY ([IdChat]) REFERENCES [orden_owner].[Chats] ([IdChat]),
	CONSTRAINT [FK_ChatMensajes_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario]),
	CONSTRAINT [FK_ChatMensajes_ChatTipoMensaje] FOREIGN KEY ([IdChatTipoMensaje]) REFERENCES [orden_owner].[ChatTiposMensaje] ([IdChatTipoMensaje])
)
GO