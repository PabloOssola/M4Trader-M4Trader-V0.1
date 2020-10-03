CREATE TABLE [shared_owner].[LogCodigoAccion] (
    [IdLogCodigoAccion] TINYINT      NOT NULL,
    [Descripcion]       VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_LogCodigoAccion] PRIMARY KEY CLUSTERED ([IdLogCodigoAccion] ASC) WITH (FILLFACTOR = 90)
);

