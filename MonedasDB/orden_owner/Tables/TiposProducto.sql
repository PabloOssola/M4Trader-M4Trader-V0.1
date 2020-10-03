CREATE TABLE [orden_owner].[TiposProducto] (
    [IdTipoProducto] TINYINT      CONSTRAINT [DF_TipoProducto_IdTipoProducto] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_TiposProducto]) NOT NULL,
    [Descripcion]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TiposProducto] PRIMARY KEY CLUSTERED ([IdTipoProducto] ASC) WITH (FILLFACTOR = 90)
);

