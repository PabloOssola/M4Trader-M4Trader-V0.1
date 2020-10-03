CREATE PROCEDURE [orden_owner].[QRY_SCRN_PERSONASLOOKUPPERSONAS_FILTERS_BUNDLE]    
@NroCliente VARCHAR(10) = NULL,        
@NombrePersona VARCHAR(100) = NULL,        
@NumeroDocumento VARCHAR(50) = NULL,        
@IdEmpresa int = NULL,      
@PageNumber bigint = 1,         
@PageSize bigint = 20,    
@IdUsuario INT,    
@TipoPersona TINYINT = NULL,    
@IdPersona INT= NULL,
@query varchar(1000)=null,
@IdPartyType int
AS        
BEGIN         
DECLARE @sql  NVARCHAR(max)    
DECLARE @params NVARCHAR(4000)       
DECLARE @partyType int
    
SET @sql = ' ;WITH pg AS (        
  SELECT        
  p.IdParty AS IdPersona
  , p.MarketCustomerNumber AS NroCliente
  , p.Name AS NombrePersona
  , p.DocumentNumber AS NroDocumento
  , UPPER(LEFT(tp.Descripcion,1))+LOWER(SUBSTRING(tp.Descripcion,2,LEN(tp.Descripcion))) TipoPersona  
  , COUNT(1) OVER() AS TotalRows        
     FROM  shared_owner.Parties p      
  INNER JOIN shared_owner.TiposPersona tp ON p.PartyType = tp.IdTipoPersona  '
  
  
SET @sql = @sql + ' WHERE '  


IF( @IdPartyType = 3 )  
 SET @sql = @sql + 'tp.IdTipoPersona in (select IdTipoPersona from shared_owner.TiposPersona where descripcion in (''LIQUIDADOR'',''NEGOCIADOR'')) and '  
 


IF( @IdPartyType = 7 )              
  SET @sql = @sql + 'tp.IdTipoPersona in (select IdTipoPersona from shared_owner.TiposPersona where descripcion = (''LIQUIDADOR'')) and '  
       
    

  
SET @sql = @sql + ' (@NroCliente IS NULL OR p.MarketCustomerNumber LIKE + ''%'' + @NroCliente + ''%'')        
  AND (@NombrePersona IS NULL OR p.Name LIKE + ''%'' + @NombrePersona + ''%'')     
  AND (@NumeroDocumento IS NULL OR p.DocumentNumber LIKE + ''%'' + @NumeroDocumento + ''%'') 
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
@IdUsuario bigint,
@IdPartyType int,
@query varchar(1000)=NULL'                              
                              
print @sql
                              
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
@IdPartyType,
@query     
    
    
     
     
END
GO

