CREATE TABLE [orden_owner].[OrdenOperacion] (
    [IdOrdenOperacion]			INT CONSTRAINT [DF_OrdenOperacion_IdOrdenOperacion] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_OrdenOperacion]) NOT NULL,
    [IdOrden]                   INT					NOT NULL,
	[Precio]					DECIMAL (20, 10)	NULL,
    [Cantidad]                  DECIMAL (18, 4)     NOT NULL,
    [NroOperacionMercado]       VARCHAR (50)        NULL,
    [NroOperacionBoleto]        INT                 NULL,
	[EquivalentRate]			DECIMAL(18,8)	    NULL,
    [OperoPorTasa]				BIT                 NOT NULL CONSTRAINT [DF_OrdenOperacion_OperoPorTasa]  DEFAULT ((0)),
	[PrecioVinculado]			DECIMAL(20,10)	    NULL,
    [Valorizacion] DECIMAL(24, 8) NULL, 
    CONSTRAINT [PK_OrdenOperacion] PRIMARY KEY CLUSTERED ([IdOrdenOperacion] ASC),
    CONSTRAINT [FK_OrdenOperacion_Ordenes] FOREIGN KEY ([IdOrden]) REFERENCES [orden_owner].[Ordenes] ([IdOrden])
);

