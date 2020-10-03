CREATE TABLE [shared_owner].[MensajesLiterales](
	[IdMensajesLiterales]	[int] CONSTRAINT [DF_MensajesLiterales_IdMensajesLiterales] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_MensajesLiterales]) NOT NULL,
	[Idioma]				[varchar](5) NULL,
	[Referencia]			[varchar](100) NULL,
	[Valor]					[varchar](max) NULL,
 CONSTRAINT [PK_MensajesLiterales] PRIMARY KEY CLUSTERED 
(
	[IdMensajesLiterales] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]