CREATE TABLE [orden_owner].[ProductosPorMercados] (
    [IdProductoPorMercado] INT     CONSTRAINT [DF_ProductosPorMercado_IdProductoPorMercado] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_ProductosPorMercado]) NOT NULL,
    [IdMercado]            TINYINT NOT NULL,
    [IdProducto]           INT     NOT NULL,
	[PrecioApertura] DECIMAL(18, 8) NULL, 
    [PrecioCierre] DECIMAL(18, 8) NULL, 
    [PrecioReferencia] DECIMAL(18, 8) NULL, 
    CONSTRAINT [PK_ProductosPorMercados] PRIMARY KEY CLUSTERED ([IdProductoPorMercado] ASC),
    CONSTRAINT [FK_ProductosPorMercado_Mercado] FOREIGN KEY ([IdMercado]) REFERENCES [shared_owner].[Mercados] ([IdMercado]),
    CONSTRAINT [FK_ProductosPorMercado_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [orden_owner].[Productos] ([IdProducto])
);

