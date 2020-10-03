CREATE TABLE [shared_owner].[RechazosMercado] (
    [IdRechazoMercado]          INT				CONSTRAINT [DF_RechazoMercado_IdRechazoMercado] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_RechazoMercado]) NOT NULL,
	[Codigo]					VARCHAR (5)		NOT NULL,
    [Descripcion]				VARCHAR (100)   NOT NULL,
    [BajaLogica]				SMALLINT        CONSTRAINT [DF_RechazoMercado_BajaLogica] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [pk_RechazosMercado] PRIMARY KEY CLUSTERED ([IdRechazoMercado] ASC) WITH (FILLFACTOR = 100, PAD_INDEX = ON)
);

