CREATE TABLE [orden_owner].[TiposOrden] (
    [IdTipoOrden]        TINYINT           CONSTRAINT [DF_TiposOrden_IdTipoOrden] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_TiposOrden]) NOT NULL,
	[Codigo]    VARCHAR (50)  NOT NULL,
    [Descripcion]    VARCHAR (100)  NOT NULL,
    CONSTRAINT [pk_TiposOrden] PRIMARY KEY CLUSTERED ([IdTipoOrden] ASC) WITH (FILLFACTOR = 100, PAD_INDEX = ON)
);

