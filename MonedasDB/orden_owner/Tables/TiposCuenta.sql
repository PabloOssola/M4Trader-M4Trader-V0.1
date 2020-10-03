CREATE TABLE [orden_owner].[TiposCuenta] (
    [IdTipoCuenta] TINYINT      CONSTRAINT [DF_TipoCuenta_IdTipoCuenta] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_TiposCuenta]) NOT NULL,
    [Descripcion]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TiposCuenta] PRIMARY KEY CLUSTERED ([IdTipoCuenta] ASC) WITH (FILLFACTOR = 90)
);

