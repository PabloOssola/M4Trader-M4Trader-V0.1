CREATE TABLE [shared_owner].[RuedasBySecurityList] (
    [IdRuedaBySecurityList]     TINYINT      CONSTRAINT [DF__RuedasBySecurityList__IdRuedaBySecurityList] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_RuedasBySecurityList]) NOT NULL,
    [Codigo]      VARCHAR (5)  NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
	[IdMercado]	  TINYINT  NOT NULL,
    [Habilitada]  BIT NOT NULL, 
    [PedirSecurityList] BIT CONSTRAINT [DF__RuedasBySecurityList__PedirSecurityList] DEFAULT ((1)) NOT NULL, 
    CONSTRAINT [PK_RuedasBySecurityList] PRIMARY KEY CLUSTERED ([IdRuedaBySecurityList] ASC) ON [FG_Fix_001],
	CONSTRAINT [FK_RuedasBySecurityList_IdMercado] FOREIGN KEY ([IdMercado]) REFERENCES [shared_owner].[Mercados] ([IdMercado])
) ON [FG_Fix_001];

