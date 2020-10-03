CREATE PROCEDURE [orden_owner].[QRY_SCRN_PERSONASLOOKUP_FILTERS_BUNDLE]        
@NroCliente VARCHAR(10) = NULL,        
@NombrePersona VARCHAR(100) = NULL,        
@NumeroDocumento VARCHAR(50) = NULL,        
@IdEmpresa int = NULL,      
@PageNumber bigint = 1,         
@PageSize bigint = 20,    
@IdUsuario INT = NULL,    
@TipoPersona TINYINT = NULL,    
@IdPersona INT= NULL,
@query varchar(1000)=null        
AS        
BEGIN         
DECLARE @sql  NVARCHAR(max)    
DECLARE @params NVARCHAR(4000)           
    
SET @sql = ' ;WITH pg AS (        
  SELECT        
  p.IdParty AS IdPersona
  , p.MarketCustomerNumber AS NroCliente
  , p.Name AS NombrePersona
  , p.DocumentNumber AS NroDocumento
  , UPPER(LEFT(tp.Descripcion,1))+LOWER(SUBSTRING(tp.Descripcion,2,LEN(tp.Descripcion))) TipoPersona  
  , EmpresaDesc = ISNULL(p2.Name,'''')  
  , COUNT(1) OVER() AS TotalRows        
     FROM  shared_owner.Parties p      
  INNER JOIN shared_owner.TiposPersona tp ON p.PartyType = tp.IdTipoPersona   
  LEFT JOIN shared_owner.PartiesHierarchy E on E.IdPartySon = P.IdParty
  LEFT JOIN shared_owner.Parties p2 ON p2.IdParty = e.IdPartyFather '
  
  
SET @sql = @sql + ' WHERE '  
  
IF( @TipoPersona = 3 )  
 SET @sql = @sql + ' P.IdParty = @IdPersona AND'  

   
IF( @TipoPersona = 6 )              
  SET @sql = @sql + ' (P.IdParty = @IdPersona or p.IdParty in (SELECT tc.IdPartySon FROM shared_owner.PartiesHierarchy  tc WHERE tc.IdPartyFather = @IdPersona)
   or p.IdParty in (SELECT tc.IdPartySon FROM shared_owner.PartiesHierarchy  tc WHERE tc.IdPartyFather in (SELECT tc.IdPartySon FROM shared_owner.PartiesHierarchy tc WHERE tc.IdPartyFather = @IdPersona))) and '   
    
IF( @TipoPersona = 7 )              
  SET @sql = @sql + ' (P.IdParty = @IdPersona OR P.IdParty IN (SELECT tc.IdPartySon FROM shared_owner.PartiesHierarchy tc WHERE tc.IdPartyFather = @IdPersona)) and'
   
IF (@TipoPersona IS NULL OR @TipoPersona <> 0)
	SET @sql = @sql + ' (tp.IdTipoPersona <> 0) and' 

  
SET @sql = @sql + ' (@NroCliente IS NULL OR p.MarketCustomerNumber LIKE + ''%'' + @NroCliente + ''%'')        
  AND (@NombrePersona IS NULL OR p.Name LIKE + ''%'' + @NombrePersona + ''%'')     
  AND (@NumeroDocumento IS NULL OR p.DocumentNumber LIKE + ''%'' + @NumeroDocumento + ''%'')        
  AND (@IdEmpresa IS NULL OR e.IdPartyFather = @IdEmpresa)      
  AND (@query IS NULL OR p.Name LIKE + ''%'' + @query + ''%'')     
     ORDER BY p.IdParty ASC         
     OFFSET @PageSize * (@PageNumber - 1) ROWS        
     FETCH NEXT @PageSize ROWS ONLY        
    )        
            
 SELECT pg.* FROM pg;    '    
    
 SET @params = N'@NroCliente VARCHAR(10) = NULL,        
@TipoPersona varchar(10) = NULL,        
@IdPersona varchar(10)= NULL,        
@NombrePersona VARCHAR(100) = NULL,        
@NumeroDocumento VARCHAR(50) = NULL,        
@IdEmpresa int = NULL,      
@PageNumber bigint = 1,         
@PageSize bigint = 20,    
@IdUsuario bigint = NULL,
@query varchar(1000)=NULL'                              
                              
--print @sql
                              
EXEC sp_executesql @sql,                              
@params,                              
@NroCliente,    
@TipoPersona,    
@IdPersona,    
@NombrePersona,    
@NumeroDocumento,    
@IdEmpresa ,    
@PageNumber,    
@PageSize ,    
@IdUsuario,
@query     
    
    
     
     
END
GO

