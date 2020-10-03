CREATE PROCEDURE [orden_owner].[QRY_SCRN_COMBOS_FILTERS_BUNDLE]
AS
BEGIN
	
	SELECT			0 as Orden, 'Mercado' as NombreCampo
	UNION SELECT	3 as Orden, 'IdTipoPersona' as NombreCampo
	UNION SELECT	4 as Orden, 'Persona' as NombreCampo
	UNION SELECT	5 as Orden, 'Moneda' as NombreCampo
	UNION SELECT	6 as Orden, 'PersoneriaJuridica' as NombreCampo
	UNION SELECT	7 as Orden, 'Portfolio' as NombreCampo
	UNION SELECT	8 as Orden, 'IdEstado' as NombreCampo
	UNION SELECT    9 as Orden, 'Plazo' as NombreCampo
	UNION SELECT    11 as Orden, 'IdSourceApplication' as NombreCampo
 	Order by Orden;

	--0
	SELECT Descripcion as NombreMercado, IdMercado  FROM shared_owner.Mercados 
	
	--3
	SELECT Descripcion as TipoPersonaDescripcion, IdTipoPersona as IdTipoPersona 
	FROM shared_owner.TiposPersona
	where IdTipoPersona > 0
	
	--4
	SELECT p.Name as NombrePersona, IdParty as IdPersona 
	FROM shared_owner.Parties p WHERE p.BajaLogica = 0

	--5
	SELECT Descripcion as NombreMoneda, IdMoneda as IdMoneda FROM shared_owner.Monedas

	--6
	SELECT Descripcion as PersoneriaJuridicaDescripcion, IdPersoneriaJuridica as IdPersoneriaJuridica FROM shared_owner.PersoneriaJuridica

	--7
	SELECT Nombre, IdPortfolio FROM orden_owner.Portfolios

	--8
	SELECT Descripcion as NombreEstado, IdEstadoOrden as Estado  FROM orden_owner.EstadosOrden

	--9
	SELECT Descripcion as NombrePlazo, IdPlazo as IdPlazo FROM orden_owner.Plazos
	 
	--11
	--SELECT Descripcion as IdSourceApplicationDescripcion, IdSourceApplication as IdSourceApplication FROM orden_owner.SourcesApplication
END