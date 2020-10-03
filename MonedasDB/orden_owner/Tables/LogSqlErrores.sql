CREATE TABLE [orden_owner].[LogSqlErrores] (
    [IdLogSqlErrores]  INT              CONSTRAINT [DF_LogSqlErrores_IdLogSqlErrores] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_LogSqlErrores]) NOT NULL,
    [Fecha]            DATETIME         NOT NULL,
    [TipoSentenciaSQL] VARCHAR (30)     NOT NULL,
    [StackTrace]       VARCHAR (MAX)    NOT NULL,
    [ParametrosSP]     VARCHAR (MAX)    NULL,
    [NombreSP]         VARCHAR (255)    NOT NULL,
    [MensajeError]     VARCHAR (MAX)    NOT NULL,
    [CallStack]        VARCHAR (MAX)    NULL,
    [IdUsuario]        INT              NULL,
    [RequestId]        UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_LOGSqlErrores] PRIMARY KEY CLUSTERED ([IdLogSqlErrores] ASC) WITH (FILLFACTOR = 95) ON [FG_Auditoria_001],
    CONSTRAINT [FK_LogSqlErrores_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
) ON [FG_Auditoria_001];



