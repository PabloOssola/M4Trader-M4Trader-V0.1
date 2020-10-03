CREATE PROCEDURE orden_owner.QRY_SCRN_SEARCHHISTORY_GRID_MAIN_ALL
    @fromDate DATETIME=NULL,
    @toDate DATETIME=NULL, 
    @chosenRange nvarchar=null,
	@PageNumber bigint=NULL, 
    @PageSize bigint=0
	 
AS                                     
BEGIN                                 
                              
DECLARE @sql  NVARCHAR(max)                                
DECLARE @sqlFrom NVARCHAR(max)                                
DECLARE @sqlWhere NVARCHAR(max)                                
DECLARE @params NVARCHAR(4000)                              
                              
SET @sql = ';WITH ordenes AS (SELECT ROW_NUMBER() OVER ( ORDER BY ( SELECT 1 ) ) AS TotalRowCount, ord.IdOrden '                               
SET @sqlFrom ='from orden_owner.Ordenes ord '
SET @sqlWhere = 'WHERE 1=1  '  
  
IF @fromDate IS NOT NULL                               
BEGIN                              
 SET @fromDate = shared_owner.fn_ARQ_ConvertirFechaAHoraInicial(@fromDate)                              
 SET @sqlWhere = @sqlWhere + 'AND Ord.FechaConcertacion >= @fromDate '                              
END                              
                              
IF @toDate IS NOT NULL                               
BEGIN                              
 SET @toDate = shared_owner.fn_ARQ_ConvertirFechaAHoraFinal(@toDate)                              
 SET @sqlWhere = @sqlWhere + 'AND Ord.FechaConcertacion <= @toDate '                                
END                              

IF @PageNumber IS NULL  OR @PageNumber = 0                             
BEGIN                              
 SET @PageNumber = 1                              
END                              

IF @PageSize IS NULL OR @PageSize = 0                               
BEGIN                              
 SET @PageSize = 15                            
END     
                                           
                                  
SET @sql = @sql + @sqlFrom + @sqlWhere + '), Total AS (SELECT TOP 1 MAX(TotalRowCount) AS CantidadTotal FROM ordenes) '                                         
                                           

                              
                              
SET @sql = @sql + 'SELECT (                          
 Select top 1 CAST(isnull(CantidadTotal,1) AS int) from total ) as TotalRows,                              
 ord.IdOrden,                              
 CASE ord.CompraVenta WHEN ''C'' THEN ''Bid'' ELSE ''Offer'' END as CompraVenta,                            
  ord.NumeroOrdenInterno,                              
	ISNULL(ord.NumeroOrdenMercado , '''') as NumeroOrdenMercado ,       
	CONVERT(datetime, 
               SWITCHOFFSET(CONVERT(datetimeoffset, 
                                    ord.FechaConcertacion), 
                            DATENAME(TzOffset, SYSDATETIMEOFFSET()))) 
       AS FechaConcertacion,                               
  ord.Cantidad,                              
 Precio = ord.PrecioLimite,                            
  MonedaDescripcion = M.Descripcion,                            
  PersonaDescripcion = PER.Name,                            
  p.codigo ProductoDescripcion,               
  Ejecutada = ISNULL(SUM(oop.Cantidad),0),      
  ord.IdEstado,                              
  CASE WHEN SUM(oop.Cantidad) IS NULL THEN 0 ELSE 1 END  IsDetalle      
 , Remanente = ABS(ord.Cantidad - ISNULL(SUM(oop.Cantidad),0))                          
 , Monto = (ord.cantidad * ord.preciolimite)                          
 , CodigoProducto = p.Codigo                          
 , CodigoMoneda = m.Codigo                          
 , Mer.Codigo AS CodigoMercado        
 , NombreParticipante = ''DEMO''                          
 , MotivoBaja = B.Descripcion                          
 , EstadoDescripcion = est.Descripcion                    
 , TipoPlazo = ord.Plazo  
 , PlazoDescripcion = ISNULL(Pl.Descripcion, '''')  
 , ord.FechaVencimiento            
 , TipoVigencia = ord.IdTipoVigencia                
 , StopType = case when preciolimite is null then 1 else 2 end                
 ,ord.timestamp as Timestamp 
 ,@PageNumber as pageNum
 , COUNT(1) OVER() AS pageSize                              
 FROM (select  orde.IdOrden FROM ordenes orde  ORDER BY orde.IdOrden DESC OFFSET  @PageSize * (@PageNumber - 1) ROWS                              
 FETCH NEXT @PageSize ROWS ONLY) orde                               
 INNER JOIN orden_owner.ordenes ord on ord.IdOrden = orde.IdOrden                              
 INNER JOIN orden_owner.EstadosOrden EST on ord.IdEstado = Est.IdEstadoOrden                          
 LEFT JOIN  shared_owner.MotivosBaja B on ord.idmotivobaja = B.idMotivoBaja                          
 LEFT JOIN  orden_owner.OrdenOperacion oop on ord.IdOrden = oop.IdOrden                              
 LEFT JOIN  orden_owner.Productos P ON ord.IdProducto = P.IdProducto                               
 LEFT JOIN  shared_owner.Monedas M ON ord.IdMoneda = M.IdMoneda                            
 LEFT JOIN  shared_owner.Parties PER ON ord.IdPersona = PER.IdParty             
 LEFT JOIN  shared_owner.Mercados Mer ON ord.IdMercado = Mer.IdMercado   
 LEFT JOIN  orden_owner.Plazos Pl ON ord.Plazo = Pl.IdPlazo '    
                   
SET @sql = @sql + ' GROUP BY ord.IdOrden, ord.Cantidad,ord.NumeroOrdenInterno,                              
 ord.NumeroOrdenMercado, ord.FechaConcertacion, P.Descripcion, ord.IdEstado, ord.CompraVenta, ord.PrecioLimite, M.Descripcion, PER.Name                            
 ,p.Codigo,m.Codigo,B.Descripcion, est.Descripcion , ord.plazo, ord.FechaVencimiento, ord.IdTipoVigencia, Mer.Codigo, Pl.Descripcion, ord.timestamp
 ORDER BY Ord.FechaConcertacion desc,  Ord.NumeroOrdenInterno DESC                         
   '                              
                              
                           
                          
SET @params = N'@fromDate DATETIME = NULL,                               
  @toDate DATETIME = NULL,                                   
  @PageNumber    INT=1,                                  
  @PageSize      INT=15'                              
                              
                              
EXEC sp_executesql @sql,                              
     @params,                              
     @fromDate,                              
     @toDate,                                  
     @PageNumber,               
     @PageSize 
                


                              
END
