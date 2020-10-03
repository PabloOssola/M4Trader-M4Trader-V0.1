CREATE TABLE [shared_owner].[TiposPersona] (
    [IdTipoPersona] TINYINT      NOT NULL DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_TiposPersona]),
    [Descripcion]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TipoParticipante] PRIMARY KEY NONCLUSTERED ([IdTipoPersona] ASC)
);

