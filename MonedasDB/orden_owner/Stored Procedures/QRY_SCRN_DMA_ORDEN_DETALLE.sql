CREATE PROCEDURE [orden_owner].[QRY_SCRN_DMA_ORDEN_DETALLE]     
 @PageNumber               INT = 1,        
 @PageSize                 INT = 15,    
 @IdOrden                  INT 
AS    
BEGIN    
    
;With  Consulta as (         
	SELECT
	   IdOrdenOperacion as id
      ,O.IdOrden as IdOrden
      ,Precio as Precio
      ,O.Cantidad as Cantidad
	  ,ord.FechaConcertacion  as Fecha
	  ,O.EquivalentRate AS Tasa
      ,(Precio* O.Cantidad) AS Monto 	
	  ,NroOperacionMercado as NroOperacionMercado
	  ,TotalRows = COUNT(1) OVER()    
  FROM 
	 [orden_owner].OrdenOperacion O    
	 INNER JOIN [orden_owner].Ordenes as ord on O.IdOrden = ord.IdOrden
  WHERE  O.IdOrden  = @IdOrden  	  
  ORDER BY O.IdOrdenOperacion
  OFFSET @PageSize * (@PageNumber - 1) ROWS  
  FETCH NEXT @PageSize ROWS ONLY  
 )        
        
 SELECT  * FROM Consulta        
    
    
END 