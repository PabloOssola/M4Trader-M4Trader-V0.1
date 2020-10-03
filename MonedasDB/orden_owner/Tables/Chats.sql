CREATE TABLE [orden_owner].[Chats](
	[IdChat]			    INT CONSTRAINT [DF__Chats__IdChat] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_Chats]) NOT NULL,
	[Nombre]				VARCHAR(100) NULL,
	[Fecha]					DATETIME NOT NULL,
    [EsGrupo]				BIT CONSTRAINT [DF__Chats__EsGrupo] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Chats] PRIMARY KEY CLUSTERED([IdChat] ASC)
)
GO
