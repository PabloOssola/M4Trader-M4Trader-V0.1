CREATE TABLE [orden_owner].[LogBitacoraOrdenes] (
    [IdLogBitacoraOrden]  INT              CONSTRAINT [DF_LogBitacoraOrdenes_IdLogBitacoraOrden] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_LogBitacoraOrdenes]) NOT NULL,
    [IdOrden]             INT              NOT NULL,
    [IdUsuario]           INT              NOT NULL,
    [Fecha]               DATETIME         NOT NULL,
    [CodigoAccion]        TINYINT          NOT NULL,
    [DetalleAccion]       VARCHAR (MAX)    NOT NULL,
    [RequestId]           UNIQUEIDENTIFIER NULL,
    [IdEstadoOrden]       TINYINT          NOT NULL,
    [IdMotivoCancelacion] TINYINT          NULL,
    [IdSourceApplication] TINYINT          NULL,
    CONSTRAINT [PK_LogBitacoraOrdenes] PRIMARY KEY CLUSTERED ([IdLogBitacoraOrden] ASC) WITH (FILLFACTOR = 95) ON [FG_Auditoria_001],
    CONSTRAINT [FK_LogBitacoraOrdenes_EstadosOrden] FOREIGN KEY ([IdEstadoOrden]) REFERENCES [orden_owner].[EstadosOrden] ([IdEstadoOrden]),
    CONSTRAINT [FK_LogBitacoraOrdenes_LogCodigoAccion] FOREIGN KEY ([CodigoAccion]) REFERENCES [shared_owner].[LogCodigoAccion] ([IdLogCodigoAccion]),
    CONSTRAINT [FK_LogBitacoraOrdenes_MotivosBaja] FOREIGN KEY ([IdMotivoCancelacion]) REFERENCES [shared_owner].[MotivosBaja] ([IdMotivoBaja]),
    CONSTRAINT [FK_LogBitacoraOrdenes_Ordenes] FOREIGN KEY ([IdOrden]) REFERENCES [orden_owner].[Ordenes] ([IdOrden]),
    --CONSTRAINT [FK_LogBitacoraOrdenes_Sources] FOREIGN KEY ([IdSourceApplication]) REFERENCES [orden_owner].[SourcesApplication] ([IdSourceApplication]),
    CONSTRAINT [FK_LogBitacoraOrdenes_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
) ON [FG_Auditoria_001];







