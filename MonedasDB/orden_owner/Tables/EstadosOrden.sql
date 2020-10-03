CREATE TABLE [orden_owner].[EstadosOrden] (
    [IdEstadoOrden]                     TINYINT              CONSTRAINT [DF_EstadosOrden_IdEstadoOrden] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_EstadosOrden]) NOT NULL,
    [Descripcion]       VARCHAR (250)  NOT NULL,
    CONSTRAINT [PK_EstadosOrden] PRIMARY KEY CLUSTERED ([IdEstadoOrden] ASC) WITH (FILLFACTOR = 90)
);

