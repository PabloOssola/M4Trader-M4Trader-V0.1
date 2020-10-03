CREATE TABLE [orden_owner].[Notificaciones](
	[IdNotificacion]        bigint CONSTRAINT [DF__Notificacion__IdNotificacion] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_Notificacion]) NOT NULL,
	[IdTipoNotificacion]	TINYINT NOT NULL,
    [IdSubTipoNotificacion]	TINYINT NOT NULL,
	[Mensaje]				VARCHAR(50) NOT NULL,
	[Fecha]					DATETIME NOT NULL,
    [Leido]					bit NOT NULL DEFAULT 0, 
    [IdDestinatario]		INT NOT NULL, 
    CONSTRAINT [PK_Notificacion] PRIMARY KEY CLUSTERED([IdNotificacion] ASC),
    CONSTRAINT [FK_Notificacion_IdDestinatario] FOREIGN KEY ([IdDestinatario]) REFERENCES [shared_owner].[parties] ([IdParty]),
    CONSTRAINT [FK_Notificacion_TipoNotificacion] FOREIGN KEY ([IdTipoNotificacion]) REFERENCES [shared_owner].[TiposNotificacion] ([idTipoNotificacion]),
    CONSTRAINT [FK_Notificacion_SubTipoNotificacion] FOREIGN KEY ([IdSubTipoNotificacion]) REFERENCES [shared_owner].[SubTiposNotificacion] ([IdSubTipoNotificacion])
)
GO
