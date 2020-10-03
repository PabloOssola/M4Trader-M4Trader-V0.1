CREATE PROCEDURE [orden_owner].[QRY_SCRN_PERSONASUSUARIOSLOOKUP_FILTERS_BUNDLE]    
@PageNumber int,    
@PageSize int,     
@tipo SMALLINT=NULL,     
  
  
@query varchar(10)=NULL,     
@NroCliente varchar(10)=NULL,     
@NroDocumento varchar(10)=NULL,     
@NombrePersona VARCHAR (100)=NULL,     
@IdPersoneriaJuridica SMALLINT=NULL,     
   
@TipoPersona SMALLINT=NULL,     
@IdPersona INT,     
@IdUsuario INT ,    
@IdEmpresa INT = NULL    
WITH RECOMPILE    
AS      
BEGIN      
     
if NOT @query IS NULL    
BEGIN    
 SET @query = '%' + @query + '%'    
END    
    
 ;WITH pg AS    
  (    
  SELECT     
   per.IdParty as IdPersona,    
   per.MarketCustomerNumber as NroCliente,    
   per.Name as NombrePersona,    
   per.DocumentNumber,    
   UPPER(LEFT(tp.Descripcion,1))+LOWER(SUBSTRING(tp.Descripcion,2,LEN(tp.Descripcion))) TipoPersona,    
   COUNT(1) OVER() AS TotalRows    
  FROM shared_owner.Parties per 
  INNER JOIN shared_owner.TiposPersona tp ON per.PartyType = tp.IdTipoPersona
  inner join shared_owner.PartiesHierarchy ph on ph.IdPartySon = per.IdParty
  WHERE     
       ((@IdPersona IS NULL) OR (per.IdParty = @IdPersona))      
   AND ((@TipoPersona IS NULL) OR (@TipoPersona = per.PartyType))      
   AND ((@IdPersoneriaJuridica IS NULL) OR (@IdPersoneriaJuridica = per.IdLegalPersonality))      
   AND ((@query IS NULL OR per.MarketCustomerNumber like @query) OR (@query IS NULL OR per.Name like @query))      
   AND ((@NroCliente IS NULL) OR (per.MarketCustomerNumber like '%'+@NroCliente+'%'))      
   AND ((@NroDocumento IS NULL) OR (per.DocumentNumber like '%'+@NroDocumento+'%'))      
   AND ((@NombrePersona IS NULL) OR (per.Name like '%'+@NombrePersona+'%'))        
   AND (@IdEmpresa IS NULL OR ph.IdPartyFather = @IdEmpresa)
   AND per.BajaLogica = 0
  ORDER BY per.IdParty OFFSET @PageSize * (@PageNumber - 1) ROWS FETCH NEXT @PageSize ROWS ONLY      
 )     
    
 SELECT * from pg    
     
END