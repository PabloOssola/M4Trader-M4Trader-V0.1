CREATE TABLE [shared_owner].[TiposNotificacion] (
    [IdTipoNotificacion] TINYINT  CONSTRAINT [DF_TipoNotificacion_IdTipoNotificacion]  NOT NULL,
    [Descripcion]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TipoNotificacion] PRIMARY KEY CLUSTERED ([IdTipoNotificacion] ASC) WITH (FILLFACTOR = 90)
);

