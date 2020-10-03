CREATE PROCEDURE [orden_owner].[QRY_SCRN_CLIENTESLOOKUP_FILTERS_BUNDLE]        
@NroCliente VARCHAR(10) = NULL,        
@tipoPersona varchar(10) = NULL,        
@idPersona varchar(10)= NULL,        
@NombrePersona VARCHAR(100) = NULL,        
@NumeroDocumento VARCHAR(50) = NULL,        
@IdEmpresa int = NULL,      
@PageNumber bigint = 1,         
@PageSize bigint = 20,
@query VARCHAR(MAX)=NULL
        
AS        
BEGIN         
 ;WITH pg AS (        
     SELECT        
      p.IdParty AS IdPersona        
      ,p.MarketCustomerNumber AS NroCliente        
      ,p.Name AS NombrePersona        
      ,p.DocumentNumber AS NroDocumento        
      ,COUNT(1) OVER() AS TotalRows        
     FROM  shared_owner.Parties p        
	 inner join shared_owner.PartiesHierarchy ph on ph.IdPartySon = p.IdParty
     WHERE        
      (@NroCliente IS NULL OR p.MarketCustomerNumber LIKE + '%' + @NroCliente + '%')        
		AND (@NombrePersona IS NULL OR p.Name LIKE + '%' + @NombrePersona + '%')        
		AND (@idPersona IS NULL OR p.IdParty LIKE + '%' + @idPersona + '%')        
		AND (@NumeroDocumento IS NULL OR p.DocumentNumber LIKE + '%' + @NumeroDocumento + '%')        
		AND (@IdEmpresa IS NULL OR ph.IdPartyFather = @IdEmpresa)
		AND (@query IS NULL OR P.Name LIKE + '%' + @query + '%')
		AND p.PartyType <> 2
     ORDER BY p.IdParty ASC         
     OFFSET @PageSize * (@PageNumber - 1) ROWS        
     FETCH NEXT @PageSize ROWS ONLY        
    )        
            
 SELECT pg.* FROM pg;        
END
GO

