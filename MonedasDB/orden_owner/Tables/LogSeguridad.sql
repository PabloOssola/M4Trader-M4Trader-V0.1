CREATE TABLE [orden_owner].[LogSeguridad] (
    [IdLogSeguridad]      INT           CONSTRAINT [DF_LogSeguridad_IdLogSeguridad] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_LogSeguridad]) NOT NULL,
	[IdLogCodigoAccion]	   TINYINT			NOT NULL,
    [IdUsuario]           INT           NULL,
    [Fecha]               DATETIME      NOT NULL,
    [Descripcion]         TEXT          NULL,
    [IdAplicacion]        TINYINT       NULL,
    [RequestId]           uniqueidentifier  NULL,
    CONSTRAINT [PK_LogSeguridad] PRIMARY KEY CLUSTERED ([IdLogSeguridad] ASC) WITH (FILLFACTOR = 95) ON [FG_Auditoria_001],
	CONSTRAINT [FK_logseguridad_idusuario] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario]),
	CONSTRAINT [FK_logseguridad_idlogcodigoaccion] FOREIGN KEY ([IdLogCodigoAccion]) REFERENCES [shared_owner].[LogCodigoAccion] ([IdLogCodigoAccion])
);

