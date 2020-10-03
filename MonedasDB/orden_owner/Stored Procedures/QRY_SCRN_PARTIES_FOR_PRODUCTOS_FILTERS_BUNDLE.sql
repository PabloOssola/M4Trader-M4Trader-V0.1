CREATE PROCEDURE [orden_owner].[QRY_SCRN_PARTIES_FOR_PRODUCTOS_FILTERS_BUNDLE]
@PageNumber        INT=0, 
@PageSize          INT=999,         
@NombrePersona VARCHAR(100) = NULL,  
@NroCliente	   VARCHAR (18) =  NULL
AS
BEGIN
	SELECT  p.MarketCustomerNumber as NroCliente,
	p.Name as NombrePersona,
	p.IdParty as IdPersona,
	COUNT(1) OVER() AS totalRows
	FROM shared_owner.Parties p
	where (@NombrePersona IS NULL OR p.Name LIKE + '%' + @NombrePersona + '%')
	and (@NroCliente IS NULL OR p.MarketCustomerNumber LIKE + '%' + @NroCliente + '%')
	ORDER BY NombrePersona
	OFFSET isnull(@PageSize,999) * isnull(@PageNumber,0) ROWS
	FETCH NEXT isnull(@PageSize,999) ROWS ONLY
END