CREATE PROCEDURE [orden_owner].[QRY_SCRN_PERSONAS_GRID_MAIN_ALL]    
	@NroCliente varchar(20)=null,    
	@NombrePersona varchar(255)=null,    
	@IdTipoPersona tinyint=null,    
	@NroDocumento varchar(50)=null,    
	@IdPersoneriaJuridica tinyint=null,    
	@IdEmpresa int = NULL,  
	@PageNumber bigint=NULL,     
    @PageSize bigint=0    
AS    
BEGIN     
 ;WITH pg AS (    
     SELECT    
      p.IdParty as IdPersona     
      , p.MarketCustomerNumber as NroCliente    
      , p.Name as NombrePersona    
      , p.PartyType AS IdTipoPersona    
      , tp.Descripcion AS TipoPersonaDescripcion    
      , p.DocumentNumber as NroDocumento    
      , p.IdLegalPersonality AS IdPersoneriaJuridica    
      , tpj.Descripcion AS PersoneriaJuridicaDescripcion  
	  , p.TaxIdentificationNumber as NroIdentificacionTributaria
	  , Telefono = ISNULL(P.Phone, '')
	  ,( select emp.Name + ', 'from shared_owner.Parties emp
				LEFT JOIN shared_owner.PartiesHierarchy ph ON ph.IdPartySon = p.IdParty
				where emp.IdParty   = ph.IdPartyFather AND (@IdEmpresa IS NULL OR ph.IdPartyFather = @IdEmpresa)
            FOR XML PATH('') ) AS EmpresaDesc
      ,COUNT(1) OVER() AS TotalRows    
     FROM  shared_owner.Parties p    
     INNER JOIN shared_owner.TiposPersona tp ON (p.PartyType = tp.IdTipoPersona)    
     INNER JOIN shared_owner.PersoneriaJuridica tpj ON (p.IdLegalPersonality = tpj.IdPersoneriaJuridica)
     WHERE     
      (@NroCliente is null OR p.MarketCustomerNumber like + '%' + @NroCliente + '%')    
		AND (@NombrePersona is null OR p.Name like + '%' + @NombrePersona + '%')		
		AND (@IdTipoPersona is null OR p.PartyType = @IdTipoPersona)    
		AND (@IdPersoneriaJuridica is null OR p.IdLegalPersonality = @IdPersoneriaJuridica)    
		AND (@NroDocumento is null OR p.DocumentNumber like + '%' + @NroDocumento + '%')
		AND p.BajaLogica = 0
     ORDER BY p.IdParty ASC     
     OFFSET @PageSize * (@PageNumber - 1) ROWS    
     FETCH NEXT @PageSize ROWS ONLY    
    )    
        
 SELECT pg.* FROM pg;    
END