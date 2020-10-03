CREATE TABLE [orden_owner].[LogProcesos] (
    [IdLogProceso]      INT              CONSTRAINT [DF_LogProcesos_IdLogProceso] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_LogProcesos]) NOT NULL,
    [IdUsuario]         INT              NOT NULL,
    [Fecha]             DATETIME         NOT NULL,
    [Descripcion]       VARCHAR (MAX)   NOT NULL,
    [Resultado]         VARCHAR (MAX)    NULL,
    [RequestId]         UNIQUEIDENTIFIER NULL,
    [IdLogCodigoAccion] TINYINT          NULL,
    CONSTRAINT [PK_LogProceso] PRIMARY KEY CLUSTERED ([IdLogProceso] ASC) WITH (FILLFACTOR = 95) ON [FG_Auditoria_001],
    CONSTRAINT [FK_logproceso_IdLogCodigoAccion] FOREIGN KEY ([IdLogCodigoAccion]) REFERENCES [shared_owner].[LogCodigoAccion] ([IdLogCodigoAccion]),
    CONSTRAINT [FK_LogProcesos_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
) ON [FG_Auditoria_001];


