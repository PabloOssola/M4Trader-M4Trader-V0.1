CREATE TABLE [shared_owner].[LogAuditoria] (
    [IdLogAuditoria] INT           CONSTRAINT [DF_LogAuditoria_IdLogAuditoria] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_LogAuditoria]) NOT NULL,
    [IdUsuario]      INT           NOT NULL,
    [FechaEvento]    DATETIME      NOT NULL,
    [TipoEvento]     TINYINT       NOT NULL,
    [IdClase]        SMALLINT      NOT NULL,
    [IdRegistro]     BIGINT        NOT NULL,
    [ValorOriginal]  VARCHAR (MAX) NULL,
    [ValorNuevo]     VARCHAR (MAX) NULL,
    CONSTRAINT [PK_LogAuditoria] PRIMARY KEY CLUSTERED ([IdLogAuditoria] ASC) WITH (FILLFACTOR = 95) ON [FG_Auditoria_001],
    CONSTRAINT [FK_LogAuditoria_LogAuditoriaClases] FOREIGN KEY ([IdClase]) REFERENCES [shared_owner].[LogAuditoriaClases] ([IdLogAuditoriaClase]),
    CONSTRAINT [FK_LogAuditoria_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
) ON [FG_Auditoria_001];



