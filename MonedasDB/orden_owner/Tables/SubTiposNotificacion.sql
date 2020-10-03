CREATE TABLE [shared_owner].[SubTiposNotificacion] (
    [IdSubTipoNotificacion] TINYINT  CONSTRAINT [DF_SubTipoNotificacion_IdSubTipoNotificacion] NOT NULL,
    [Descripcion]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SubTipoNotificacion] PRIMARY KEY CLUSTERED ([IdSubTipoNotificacion] ASC) WITH (FILLFACTOR = 90)
);

