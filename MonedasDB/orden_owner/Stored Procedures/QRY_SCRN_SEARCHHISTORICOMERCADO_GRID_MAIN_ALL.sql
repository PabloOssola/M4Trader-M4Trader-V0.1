CREATE PROCEDURE [orden_owner].[QRY_SCRN_SEARCHHISTORICOMERCADO_GRID_MAIN_ALL]
@IdPersona int=null,
@PageNumber bigint=NULL, 
@PageSize bigint=0,
@Portfolio VARCHAR (50) = NULL,
@Especie VARCHAR (50) = NULL,
@FechaDesde DATETIME=NULL,
@FechaHasta DATETIME=NULL
	 
AS
BEGIN 
	DECLARE @Dias	INT
	set @Dias = CASE WHEN @IdPersona IS NULL THEN  1 ELSE  30 END
	IF (@FechaDesde IS NULL or @FechaDesde < GETDATE() - @Dias)
		SELECT @FechaDesde = convert(datetime,CONVERT(varchar(10), GETDATE() - @Dias, 103),103);
	IF @FechaHasta IS NULL
		SELECT @FechaHasta = convert(datetime,CONVERT(varchar(10), GETDATE() + 1, 103),103);
					
IF (@IdPersona IS NULL)
BEGIN
	;WITH historicas AS (
select oh.IdOperacionHistorico as ID
,TradeReportID as Secuencia
,p.Nombre as Portfolio
,prod.Codigo as Posicion
 ,pl.Descripcion as Tipo
 , m.Descripcion as Moneda
 ,case when oh.OperaPorTasa =0 then  oh.PrecioTasa else null end as Precio
  ,case when oh.OperaPorTasa =1 then  oh.PrecioTasa else null end as Tasa
 ,oh.Cantidad
 ,oh.Valorizacion as Total
 ,oh.Fecha
 ,oh.EsAlta
 ,pl.Descripcion as Plazo
 ,oh.OperaPorTasa
 ,ord.Precio as PrecioMercado
 ,'' ContraparteCompradora
 ,'' ContraparteVendedora,
			COUNT(1) OVER() AS totalRows       
from [orden_owner].[OperacionHistorico] oh
inner join orden_owner.PortfoliosComposicion pc on oh.IdProducto = pc.IdProducto
inner join orden_owner.Portfolios p on pc.IdPortfolio = p.IdPortfolio
inner join orden_owner.Productos prod on prod.IdProducto = pc.IdProducto
INNER JOIN STRING_SPLIT(ISNULL(@Portfolio,''), '#') bus ON p.Nombre Like '%' + isnull(bus.value,p.Nombre)+'%'
INNER JOIN STRING_SPLIT(ISNULL(@Especie,''), '#') busProd ON prod.Codigo Like '%' + isnull(busProd.value,prod.Codigo)+'%'
inner join shared_owner.Monedas m on m.IdMoneda = oh.IdMoneda
INNER join orden_owner.Plazos pl on pl.IdPlazo = oh.IdPlazo
left join (
select o.IdProducto, MAX(IdOrdenOperacion) as maxId
from orden_owner.Ordenes o
inner join orden_owner.OrdenOperacion oo on o.IdOrden = oo.IdOrden
group by IdProducto) maxo on maxo.IdProducto = pc.IdProducto
left join orden_owner.OrdenOperacion ord on ord.IdOrdenOperacion = maxo.maxId
where (oh.Fecha >= @FechaDesde and oh.Fecha < @FechaHasta)
					ORDER BY oh.IdOperacionHistorico ASC 
					OFFSET @PageSize * (@PageNumber - 1) ROWS
					FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT historicas.* FROM historicas;
END
ELSE
BEGIN
	;WITH historicas AS (
select oh.IdOperacionHistorico as ID
,TradeReportID as Secuencia
,p.Nombre as Portfolio
,prod.Codigo as Posicion
 ,pl.Descripcion as Tipo
 , m.Descripcion as Moneda
 ,case when oh.OperaPorTasa =0 then  oh.PrecioTasa else null end as Precio
  ,case when oh.OperaPorTasa =1 then  oh.PrecioTasa else null end as Tasa
 ,oh.Cantidad
 ,oh.Valorizacion as Total
 ,oh.Fecha
 ,oh.EsAlta
 ,pl.Descripcion as Plazo
 ,oh.OperaPorTasa
 ,ord.Precio as PrecioMercado
 ,oh.PartyComprador ContraparteCompradora
 ,oh.PartyVendedor ContraparteVendedora,
			COUNT(1) OVER() AS totalRows       
from [orden_owner].[OperacionHistorico] oh
inner join orden_owner.PortfoliosComposicion pc on oh.IdProducto = pc.IdProducto
inner join orden_owner.Portfolios p on pc.IdPortfolio = p.IdPortfolio
inner join orden_owner.Productos prod on prod.IdProducto = pc.IdProducto
INNER JOIN STRING_SPLIT(ISNULL(@Portfolio,''), '#') bus ON p.Nombre Like '%' + isnull(bus.value,p.Nombre)+'%'
INNER JOIN STRING_SPLIT(ISNULL(@Especie,''), '#') busProd ON prod.Codigo Like '%' + isnull(busProd.value,prod.Codigo)+'%'
inner join shared_owner.Monedas m on m.IdMoneda = oh.IdMoneda
INNER join orden_owner.Plazos pl on pl.IdPlazo = oh.IdPlazo
left join (
select o.IdProducto, MAX(IdOrdenOperacion) as maxId
from orden_owner.Ordenes o
inner join orden_owner.OrdenOperacion oo on o.IdOrden = oo.IdOrden
group by IdProducto) maxo on maxo.IdProducto = pc.IdProducto
left join orden_owner.OrdenOperacion ord on ord.IdOrdenOperacion = maxo.maxId
left join shared_owner.Parties part1 on (oh.PartyVendedor = part1.AgentCode OR oh.PartyComprador = part1.AgentCode)
where (@IdPersona is null or part1.IdParty = @IdPersona) and 
 (oh.Fecha >= @FechaDesde and oh.Fecha < @FechaHasta)
					ORDER BY oh.IdOperacionHistorico ASC 
					OFFSET @PageSize * (@PageNumber - 1) ROWS
					FETCH NEXT @PageSize ROWS ONLY
				)
				
	SELECT historicas.* FROM historicas;
END
END