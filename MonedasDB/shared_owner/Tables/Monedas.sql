CREATE TABLE [shared_owner].[Monedas] (
    [IdMoneda]    TINYINT      CONSTRAINT [DF__Monedas__IdMoneda] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_Monedas]) NOT NULL,
    [Codigo]      VARCHAR (8)  NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [TipoMoneda]  TINYINT      NOT NULL,
	[CodigoISO]   VARCHAR (4)  NOT NULL,
    [EsMonedaNacional] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Monedas] PRIMARY KEY CLUSTERED ([IdMoneda] ASC),
    CONSTRAINT [FK_Monedas_TiposMoneda] FOREIGN KEY ([TipoMoneda]) REFERENCES [shared_owner].[TiposMoneda] ([IdTipoMoneda])
);

