CREATE TABLE [orden_owner].[LogCommand] (
    [IdLogCommand]  INT              CONSTRAINT [DF_LogCommand_IdLogCommand] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_LogCommand]) NOT NULL,
    [IdUsuario]     INT              NULL,
    [CommandName]   VARCHAR (100)    NOT NULL,
    [Codigo]        VARCHAR (15)     NOT NULL,
    [StartDateTime] DATETIME         NOT NULL,
    [RequestId]     UNIQUEIDENTIFIER NOT NULL,
    [Argument]      VARCHAR (MAX)    NOT NULL,
    [IdSesion]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_LOGCommand] PRIMARY KEY CLUSTERED ([IdLogCommand] ASC) WITH (FILLFACTOR = 95) ON [FG_Auditoria_001],
    CONSTRAINT [FK_LogCommand_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
) ON [FG_Auditoria_001];



