CREATE TABLE [shared_owner].[SecurityList] (
    [IdSecurityList]		INT      CONSTRAINT [DF__SecurityList__IdSecurityList] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_SecurityList]) NOT NULL,
    [CodigoProducto]		VARCHAR(32) NOT NULL,
	[IdMercado]				TINYINT  NOT NULL,
    [Habilitada]			BIT NOT NULL, 
	[SegmentMarketId]		VARCHAR(10), 
    CONSTRAINT [PK_SecurityList] PRIMARY KEY CLUSTERED ([IdSecurityList] ASC) ON [FG_Fix_001],
	CONSTRAINT [FK_SecurityList_IdMercado] FOREIGN KEY ([IdMercado]) REFERENCES [shared_owner].[Mercados] ([IdMercado])
) ON [FG_Fix_001];

