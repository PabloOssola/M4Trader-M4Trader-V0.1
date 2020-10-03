CREATE TABLE [orden_owner].[PreciosHistoricos] (
    [IdPrecioHistorico] BIGINT          CONSTRAINT [DF__PreciosHistoricos__IdPrecioHistorico] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_PreciosHistoricos]) NOT NULL,
    [IdMercado]         TINYINT         NOT NULL,
    [Precio]            DECIMAL (18, 8) NOT NULL,
    [Cantidad]          DECIMAL (18, 4) NOT NULL,
    [Fecha]             DATETIME        NOT NULL,
    [IdMoneda]          TINYINT         NOT NULL,
	[CompraVenta]		VARCHAR(1)		CONSTRAINT [DF_PreciosHistoricos_CompraVenta]  DEFAULT 'C' NOT NULL,
    CONSTRAINT [PK_PreciosHistoricos] PRIMARY KEY CLUSTERED ([IdPrecioHistorico] ASC),
    CONSTRAINT [FK_PreciosHistoricos_IdMoneda] FOREIGN KEY ([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda]),
    CONSTRAINT [FK_PreciosHistoricos_Mercados] FOREIGN KEY ([IdMercado]) REFERENCES [shared_owner].[Mercados] ([IdMercado]),
);


