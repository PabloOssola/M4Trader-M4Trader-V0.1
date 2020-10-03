CREATE TABLE [orden_owner].[Precios] (
    [IdPrecio]           SMALLINT        CONSTRAINT [DF__Precios__IdPrecio] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_Precios]) NOT NULL,
    [IdMoneda]         TINYINT             NOT NULL,
    [IdMercado]          TINYINT         NOT NULL,
    [Precio]             DECIMAL (18, 8) NOT NULL,
    [ClosingPrice]		 DECIMAL (18, 8) NULL,
    [Cantidad]           DECIMAL (18, 4) NOT NULL,
    [Fecha]              DATETIME        NOT NULL, 
    [IndexValue]		 DECIMAL (18, 8) NULL,
    [OpeningPrice]		 DECIMAL (18, 8) NULL,
    [SettlementPrice]	 DECIMAL (18, 8) NULL,
    [TradingHighPrice]	 DECIMAL (18, 8) NULL,
    [TradingLowPrice]	 DECIMAL (18, 8) NULL,
    [TradeVolume]        DECIMAL (18, 4) NULL,
    [OpenInterest]       DECIMAL (18, 4) NULL,
    [EquivalentRate]	 DECIMAL (18, 4) NULL, 
	[SettlementDate]     DATETIME        NULL,
	[CompraVenta]		 VARCHAR(1)	CONSTRAINT [DF_Precios_CompraVenta]  DEFAULT 'C' NOT NULL,
    CONSTRAINT [PK_Precios] PRIMARY KEY CLUSTERED ([IdPrecio] ASC),
    CONSTRAINT [FK_Precios_Mercado] FOREIGN KEY ([IdMercado]) REFERENCES [shared_owner].[Mercados] ([IdMercado]), 
    CONSTRAINT [FK_Precios_Monedas] FOREIGN KEY ([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda])
);




