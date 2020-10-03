CREATE TABLE [precios_owner].[CollateralReport](
	IdCollateralReport	INT CONSTRAINT [DF_CollateralReport_IdCollateralReport] DEFAULT (NEXT VALUE FOR [precios_owner].[SQ_CollateralReport]) NOT NULL,
	ClearingHouse			VARCHAR(8)		NOT NULL,
	Giver					VARCHAR(8)		NOT NULL,
	Receiver				VARCHAR(8)		NOT NULL,
	IdCurrency				TINYINT			NOT NULL,
	TotalAmount				BIGINT			NOT NULL,
	ConsumedAmount			BIGINT			NOT NULL,
	ConsumedChips			BIGINT			NOT NULL,
    CONSTRAINT [PK_CollateralReport] PRIMARY KEY ([IdCollateralReport]),
    CONSTRAINT [FK_CollateralReport_IdCurrency] FOREIGN KEY ([IdCurrency]) REFERENCES [shared_owner].[Monedas] ([IdMoneda])
) ON [FG_Precios_001]
GO
