CREATE PROCEDURE [precios_owner].[GAR_GetGarantiasAgenteLogueado]
  @IdUsuario	INT
AS
BEGIN

	DECLARE @Agente SMALLINT

		SELECT @Agente = p.MarketCustomerNumber FROM shared_owner.Usuarios u
		INNER JOIN shared_owner.Parties p ON p.IdParty = u.IdPersona
		WHERE u.IdUsuario = @IdUsuario

		SELECT cr.IdCollateralReport,
		cr.ClearingHouse,
		cr.Giver,
		cr.Receiver,
		cr.IdCurrency,
		m.CodigoISO AS Moneda,
		cr.TotalAmount,
		cr.ConsumedAmount,
		cr.ConsumedChips
		FROM precios_owner.CollateralReport cr 
		INNER JOIN shared_owner.Monedas m ON cr.IdCurrency = m.IdMoneda
		WHERE cr.Receiver = @Agente

END
