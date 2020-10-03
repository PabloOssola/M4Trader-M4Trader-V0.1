CREATE TABLE [shared_owner].[LogAuditoriaClases] (
    [IdLogAuditoriaClase] SMALLINT       NOT NULL,
    [NombreEntidad]       VARCHAR (255)  NOT NULL,
    [NombreClase]         VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_LogAuditoriaClases] PRIMARY KEY CLUSTERED ([IdLogAuditoriaClase] ASC) WITH (FILLFACTOR = 95) ON [FG_Auditoria_001]
);

