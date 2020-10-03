CREATE TABLE [orden_owner].[Portfolios] (
    [IdPortfolio] SMALLINT     CONSTRAINT [DF__Portfolios__IdPortfolio] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_Portfolios]) NOT NULL,
    [Nombre]      VARCHAR (50) NOT NULL,
	[Codigo]      VARCHAR (5)  NOT NULL,
    [EsDeSistema] BIT          NOT NULL,
    [EsFavorito]  BIT			NOT NULL CONSTRAINT [DF_Portfolios_EsFavorito]  DEFAULT ((0)),
    CONSTRAINT [PK_Portfolios] PRIMARY KEY CLUSTERED ([IdPortfolio] ASC)
);




