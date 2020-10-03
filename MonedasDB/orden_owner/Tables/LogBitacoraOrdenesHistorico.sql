CREATE TABLE [orden_owner].[LogBitacoraOrdenesHistorico] (
    [IdLogBitacoraOrdenesHistorico]  INT     NOT NULL,
    [IdOrden]             INT              NOT NULL,
    [IdUsuario]           INT              NOT NULL,
    [Fecha]               DATETIME         NOT NULL,
    [CodigoAccion]        TINYINT          NOT NULL,
    [DetalleAccion]       VARCHAR (MAX)    NOT NULL,
    [RequestId]           UNIQUEIDENTIFIER NULL,
    [IdEstadoOrden]       TINYINT          NOT NULL,
    [IdMotivoCancelacion] TINYINT          NULL,
    [IdSourceApplication] TINYINT          NULL,
    CONSTRAINT [PK_LogBitacoraOrdenesHistorico] PRIMARY KEY CLUSTERED ([IdLogBitacoraOrdenesHistorico] ASC) WITH (FILLFACTOR = 95) ON [FG_Auditoria_001],
) ON [FG_Auditoria_001];







