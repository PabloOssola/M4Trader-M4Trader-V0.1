CREATE PROCEDURE [orden_owner].[QRY_SCRN_MERCADOS_PORTFOLIOSEMPRESAS_FILTERS_BUNDLE]
AS
BEGIN
	SELECT Codigo as NombreMercado, IdMercado as Mercado FROM shared_owner.Mercados
END