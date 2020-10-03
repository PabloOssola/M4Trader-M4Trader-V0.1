CREATE TABLE [shared_owner].[PersoneriaJuridica] (
    [IdPersoneriaJuridica] TINYINT      NOT NULL,
    [Descripcion]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PersoneriaJuridica] PRIMARY KEY NONCLUSTERED ([IdPersoneriaJuridica] ASC)
);

