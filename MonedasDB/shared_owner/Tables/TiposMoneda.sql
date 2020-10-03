CREATE TABLE [shared_owner].[TiposMoneda] (
    [IdTipoMoneda] TINYINT      NOT NULL DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_TiposMoneda]),
    [Descripcion]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TiposMoneda] PRIMARY KEY NONCLUSTERED ([IdTipoMoneda] ASC)
);

