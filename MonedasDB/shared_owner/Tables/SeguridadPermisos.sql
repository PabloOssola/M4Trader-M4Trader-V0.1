CREATE TABLE [shared_owner].[SeguridadPermisos] (
    [IdSeguridadPermiso] TINYINT        CONSTRAINT [DF_SeguridadPermisos_IdSeguridadPermiso] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_SeguridadPermisos]) NOT NULL,
    [IdPermiso]          BIGINT         NOT NULL,
    [Descripcion]        NVARCHAR (200) NULL,
    CONSTRAINT [PK_SeguridadPermisos] PRIMARY KEY CLUSTERED ([IdSeguridadPermiso] ASC),
    CONSTRAINT [UQ_SeguridadPermisos_IdPermiso] UNIQUE NONCLUSTERED ([IdPermiso] ASC),
    CONSTRAINT [UQ_SeguridadPermisos_IdSeguridadPermiso] UNIQUE NONCLUSTERED ([IdSeguridadPermiso] ASC)
);

