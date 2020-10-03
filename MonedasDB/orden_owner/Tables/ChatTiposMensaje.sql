CREATE TABLE [orden_owner].[ChatTiposMensaje] (
    [IdChatTipoMensaje] TINYINT      CONSTRAINT [DF_ChatTipoMensaje_IdChatTipoMensaje] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_ChatTipoMensaje]) NOT NULL,
    [Descripcion]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ChatTiposMensaje] PRIMARY KEY CLUSTERED ([IdChatTipoMensaje] ASC) WITH (FILLFACTOR = 90)
);

