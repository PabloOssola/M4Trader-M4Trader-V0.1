CREATE TABLE [orden_owner].[PortfoliosComposicion] (
    [IdPortfoliosComposicion] INT      CONSTRAINT [DF_PortfoliosComposicion_IdPortfoliosComposicion] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_PortfoliosComposicion]) NOT NULL,
    [IdPortfolio]             SMALLINT NOT NULL,
    [IdMoneda]                 TINYINT      NOT NULL,
    [IdMercado]               TINYINT  NOT NULL, 
    [Orden]                   INT      NOT NULL,
    CONSTRAINT [PK_PortfoliosComposicion] PRIMARY KEY CLUSTERED ([IdPortfoliosComposicion] ASC),
    CONSTRAINT [FK_PortfoliosComposicion_Mercado] FOREIGN KEY ([IdMercado]) REFERENCES [shared_owner].[Mercados] ([IdMercado]), 
    CONSTRAINT [FK_PortfoliosComposicion_Portfolios] FOREIGN KEY ([IdPortfolio]) REFERENCES [orden_owner].[Portfolios] ([IdPortfolio]),
    CONSTRAINT [FK_PortfoliosComposicion_Productos] FOREIGN KEY ([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda])
);




