CREATE PROCEDURE [orden_owner].[QRY_SCRN_PORTFOLIOS_FILTERS_BUNDLE]
@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Nombre, IdPortfolio, Codigo
	FROM(
		SELECT Nombre, p.IdPortfolio, pu.PorDefecto, p.Codigo 
		FROM orden_owner.Portfolios p
			INNER JOIN orden_owner.PortfolioUsuario pu ON p.IdPortfolio = pu.IdPortfolio
		WHERE pu.IdUsuario = @IdUsuario) A 
	ORDER BY A.PorDefecto DESC
END