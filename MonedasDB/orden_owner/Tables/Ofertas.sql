CREATE TABLE [orden_owner].[Ofertas] (
    [IdOferta]       INT             CONSTRAINT [DF__Ofertas__IdOfertas] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_Ofertas]) NOT NULL,
    [IdProducto]     INT             NOT NULL,
    [IdMercado]      TINYINT         NOT NULL,
    [Precio]         DECIMAL (18, 8) NOT NULL,
    [Cantidad]       DECIMAL (18, 4) NOT NULL,
    [CompraVenta]    CHAR (1)        NOT NULL,
    [NumeroPosicion] TINYINT         NOT NULL,
    [Fecha]          DATETIME        NULL,
    [Plazo]          TINYINT         NOT NULL,
	[EquivalentRate] DECIMAL(18, 8)	 NULL,
	[NumeroDeOfertas] INT			 NOT NULL CONSTRAINT [DF_Ofertas_NumeroDeOfertas]  DEFAULT ((0)),
    [Valorizacion] DECIMAL(24, 8)	 NULL,
	[SettlementDate]     DATETIME    NULL,
    CONSTRAINT [PK_Ofertas] PRIMARY KEY CLUSTERED ([IdOferta] ASC),
    CONSTRAINT [FK_Ofertas_Mercados] FOREIGN KEY ([IdMercado]) REFERENCES [shared_owner].[Mercados] ([IdMercado]),
    CONSTRAINT [FK_Ofertas_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [orden_owner].[Productos] ([IdProducto])
);






