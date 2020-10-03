CREATE TABLE [orden_owner].[OrdenOperacionHistorico] (
    [IdOrdenOperacionHistorico]	INT  NOT NULL,
	[IdOrden]                   INT					NOT NULL,
	[Precio]					DECIMAL (20, 10)	NULL,
    [Cantidad]                  DECIMAL (18, 4)     NOT NULL,
    [NroOperacionMercado]       VARCHAR (50)        NULL,
    [NroOperacionBoleto]        INT                 NULL,
	[EquivalentRate]			DECIMAL(18,8)	    NULL,
    [OperoPorTasa]				BIT                 NOT NULL CONSTRAINT [DF_OrdenOperacionHistorico_OperoPorTasa]  DEFAULT ((0)),
	[PrecioVinculado]			DECIMAL(20,10)	    NULL,
    CONSTRAINT [PK_OrdenOperacionHistorico] PRIMARY KEY CLUSTERED ([IdOrdenOperacionHistorico] ASC)
);

