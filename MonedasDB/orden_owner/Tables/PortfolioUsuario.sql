CREATE TABLE [orden_owner].[PortfolioUsuario] (
    [IdPortfolioUsuario] INT      CONSTRAINT [DF_PortfoliosUsuario_IdPortfoliosUsuario] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_PortfoliosUsuario]) NOT NULL,
    [IdUsuario]          INT      NULL,
    [IdPortfolio]        SMALLINT NULL,
    [PorDefecto]		 BIT       NULL, 
    CONSTRAINT [PK_PortfolioUsuario_1] PRIMARY KEY CLUSTERED ([IdPortfolioUsuario] ASC),
    CONSTRAINT [FK_PortfolioUsuario_Portfolios] FOREIGN KEY ([IdPortfolio]) REFERENCES [orden_owner].[Portfolios] ([IdPortfolio]),
    CONSTRAINT [FK_PortfolioUsuario_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
);


