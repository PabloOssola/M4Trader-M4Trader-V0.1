CREATE TABLE [precios_owner].[HistoricoCierresSemana](
	IdHistoricoCierresSemana	INT CONSTRAINT [DF_HistoricoCierresSemana_IdHistoricoCierresSemana] DEFAULT (NEXT VALUE FOR [precios_owner].[SQ_HistoricoCierresSemana]) NOT NULL,
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
    CONSTRAINT [PK_HistoricoCierresSemana] PRIMARY KEY ([IdHistoricoCierresSemana]),
    CONSTRAINT [FK_HistoricoCierresSemana_IdProducto] FOREIGN KEY ([IdProducto]) REFERENCES [orden_owner].[Productos] ([IdProducto]),
    CONSTRAINT [FK_HistoricoCierresSemana_IdMoneda] FOREIGN KEY ([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda])
) ON [FG_Precios_001]
GO
