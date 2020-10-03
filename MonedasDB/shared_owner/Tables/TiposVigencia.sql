CREATE TABLE [shared_owner].[TiposVigencia] (
    [IdTipoVigencia]        TINYINT           CONSTRAINT [DF_TiposVigencia_IdTipoVigencia] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_TiposVigencia]) NOT NULL,
    [Descripcion]    VARCHAR (100)  NOT NULL,
    CONSTRAINT [pk_TiposVigencia] PRIMARY KEY CLUSTERED ([IdTipoVigencia] ASC) WITH (FILLFACTOR = 100, PAD_INDEX = ON)
);

