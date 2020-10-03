CREATE TABLE [shared_owner].[HistoricoPassword] (
    [IdHistoricoPassword]  INT    CONSTRAINT [DF_HistoricoPassword_IdHistoricoPassword] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_HistoricoPassword]) NOT NULL,
    [IdUsuario]            INT    NOT NULL,
    [Pass]                 VARCHAR(32)  NOT NULL,
    [Fecha]                DATETIME     NOT NULL,
    CONSTRAINT [PK_HistoricoPassword] PRIMARY KEY CLUSTERED ([IdHistoricoPassword] ASC) WITH (FILLFACTOR = 90),
	CONSTRAINT [FK_HistoricoPassword_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
);

