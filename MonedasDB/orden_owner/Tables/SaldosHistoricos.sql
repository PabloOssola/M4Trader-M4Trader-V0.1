CREATE TABLE [orden_owner].[SaldosHistoricos] (
    [IdSaldoHistorico]             INT             CONSTRAINT [DF_SaldosHistoricos_IdSaldo] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_SaldosHistoricos]) NOT NULL,
    [IdPersona]           INT             NOT NULL,
    [IdTipoProducto]      TINYINT         NOT NULL,  
    [Importe]               DECIMAL (18, 4) NOT NULL,
    [IdMoneda]            TINYINT         NOT NULL,
    [NumeroCuenta]        VARCHAR (50)    NULL,
    [IdTipoCuenta]        TINYINT         NULL,
    [Fecha]               DATETIME NOT NULL, 
    CONSTRAINT [PK_SaldosHistoricos] PRIMARY KEY CLUSTERED ([IdSaldoHistorico] ASC),
    CONSTRAINT [FK_SaldosHistoricos_Parties] FOREIGN KEY ([IdPersona]) REFERENCES [shared_owner].[Parties] ([IdParty]),
    CONSTRAINT [FK_SaldosHistoricos_TiposCuenta] FOREIGN KEY ([IdTipoCuenta]) REFERENCES [orden_owner].[TiposCuenta] ([IdTipoCuenta]),
    CONSTRAINT [FK_SaldosHistoricos_TiposProductos] FOREIGN KEY ([IdTipoProducto]) REFERENCES [orden_owner].[TiposProducto] ([IdTipoProducto]),
    CONSTRAINT [FK_SaldosHistoricos_Monedas] FOREIGN KEY([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda])
);





