CREATE TABLE [precios_owner].[HistoricoCierresMes](
	IdHistoricoCierresMes	INT CONSTRAINT [DF_HistoricoCierresMes_IdHistoricoCierresMes] DEFAULT (NEXT VALUE FOR [precios_owner].[SQ_HistoricoCierresMes]) NOT NULL,
	FechaDesde				DATE			NOT NULL,
	FechaHasta				DATE			NOT NULL,
	IdProducto				INT				NOT NULL,
	IdMoneda				TINYINT			NOT NULL,
	MontoOperado			DECIMAL(18, 8)	NOT NULL,
	Cantidad				DECIMAL(18, 4)	NOT NULL,
	PrecioCierre			DECIMAL(18, 8)	NOT NULL,
	PrecioApertura			DECIMAL(18, 8)	NOT NULL,
	PrecioMinimo			DECIMAL(18, 8)	NOT NULL,
	PrecioMaximo			DECIMAL(18, 8)	NOT NULL,
    CONSTRAINT [PK_HistoricoCierresMes] PRIMARY KEY ([IdHistoricoCierresMes]),
    CONSTRAINT [FK_HistoricoCierresMes_IdProducto] FOREIGN KEY ([IdProducto]) REFERENCES [orden_owner].[Productos] ([IdProducto]),
    CONSTRAINT [FK_HistoricoCierresMes_IdMoneda] FOREIGN KEY ([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda])
) ON [FG_Precios_001]
GO
