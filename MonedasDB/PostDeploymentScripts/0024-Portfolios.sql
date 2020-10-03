DECLARE 
@IdPortfolio smallint,
@IdMercado tinyint

-- PORTFOLIO
IF NOT EXISTS (SELECT 1 FROM orden_owner.Portfolios WHERE codigo = 'CPC2')
BEGIN
	INSERT INTO [orden_owner].[Portfolios] ([Nombre],[Codigo],[EsDeSistema]) VALUES ('Dólar Futuro','CPC2',1)
END

SELECT @IdPortfolio = MAX(IdPortfolio) FROM [orden_owner].[Portfolios]
SELECT TOP(1) @IdMercado = IdMercado FROM shared_owner.[Mercados]

-- PORTFOLIO COMPOSICION
IF NOT EXISTS (SELECT 1 FROM orden_owner.PortfoliosComposicion)
BEGIN
	INSERT INTO [orden_owner].[PortfoliosComposicion]
			   (
				[IdPortfolio]
			   ,[IdProducto]
			   ,[IdMercado]
			   ,[Orden]
			   ,[IdPlazo])
		 SELECT TOP(25)
		 @IdPortfolio,
		 IdProducto,
		 @IdMercado,
		 1,
		 1
		 FROM
		 [orden_owner].[Productos]
END

-- PORTFOLIO USUARIO
IF NOT EXISTS (SELECT 1 FROM orden_owner.PortfolioUsuario)
BEGIN
	INSERT INTO orden_owner.PortfolioUsuario ([IdPortfolio],[IdUsuario],[PorDefecto])
		 SELECT @IdPortfolio, IdUsuario, 1 FROM [shared_owner].[Usuarios] WHERE Proceso = 0
END