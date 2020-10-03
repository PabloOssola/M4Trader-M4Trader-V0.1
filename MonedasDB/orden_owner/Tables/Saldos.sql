CREATE TABLE [orden_owner].[Saldos] (
    [IdSaldo]             INT             CONSTRAINT [DF_Saldos_IdSaldo] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_Saldo]) NOT NULL,
    [IdPersona]           INT             NOT NULL,
    [IdTipoProducto]      TINYINT         NOT NULL,
    [Importe]             DECIMAL (18, 4) NOT NULL,
    [IdMoneda]            TINYINT         NOT NULL,
    [NumeroCuenta]        VARCHAR (50)    NULL,
    [IdTipoCuenta]        TINYINT         NULL,
    [UltimaActualizacion] TIMESTAMP NOT NULL, 
    [SaldoPendienteAcreditacion] DECIMAL(18, 4) NULL, 
    CONSTRAINT [PK_Saldos] PRIMARY KEY CLUSTERED ([IdSaldo] ASC),
    CONSTRAINT [FK_Saldos_Parties] FOREIGN KEY ([IdPersona]) REFERENCES [shared_owner].[Parties] ([IdParty]),
    CONSTRAINT [FK_Saldos_TiposCuenta] FOREIGN KEY ([IdTipoCuenta]) REFERENCES [orden_owner].[TiposCuenta] ([IdTipoCuenta]),
    CONSTRAINT [FK_Saldos_TiposProductos] FOREIGN KEY ([IdTipoProducto]) REFERENCES [orden_owner].[TiposProducto] ([IdTipoProducto]),
    CONSTRAINT [FK_Saldos_Monedas] FOREIGN KEY([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda])
);





