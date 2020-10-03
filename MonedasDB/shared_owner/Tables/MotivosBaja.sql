CREATE TABLE [shared_owner].[MotivosBaja] (
    [IdMotivoBaja]      TINYINT           CONSTRAINT [DF_MotivoBaja_IdMotivoBaja] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_MotivosBaja]) NOT NULL,
    [Descripcion]		VARCHAR (100)  NOT NULL,
    [EventoTipo]        NCHAR (20)    NULL,
    CONSTRAINT [PK_OrdenesMotivosbaja] PRIMARY KEY CLUSTERED ([IdMotivoBaja] ASC) WITH (FILLFACTOR = 100, PAD_INDEX = ON)
);

