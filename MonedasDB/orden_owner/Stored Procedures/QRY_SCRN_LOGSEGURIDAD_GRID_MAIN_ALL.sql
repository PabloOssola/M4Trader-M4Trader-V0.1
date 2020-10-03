CREATE PROCEDURE orden_owner.QRY_SCRN_LOGSEGURIDAD_GRID_MAIN_ALL  
  @FechaDesde DATETIME = NULL  
 ,@FechaHasta  DATETIME = NULL  
 ,@Descripcion nvarchar(max)= null  
 ,@IdUsuario int = NULL  
 ,@Codigo nvarchar(max) = NULL  
 ,@PageNumber BIGINT = 1  
 ,@PageSize BIGINT = 100  
 WITH EXECUTE AS CALLER  
AS  
BEGIN  
  
SET NOCOUNT ON;  
  
DECLARE @sql NVARCHAR(max)  
DECLARE @sqlFrom NVARCHAR(max)  
DECLARE @sqlWhere NVARCHAR(max)  
DECLARE @params NVARCHAR(4000)  
  
IF @FechaDesde IS NOT NULL  
 set @FechaDesde = shared_owner.fn_ARQ_ConvertirFechaAHoraInicial(@FechaDesde)  
IF @FechaHasta IS NOT NULL  
 set @FechaHasta = shared_owner.fn_ARQ_ConvertirFechaAHoraFinal(@FechaHasta)  
   
 SET @sql = ';WITH LogSeguridad AS (   
    SELECT ROW_NUMBER() OVER ( ORDER BY ( SELECT 1 ) ) AS TotalRowCount, IdLogSeguridad '  
 SET @sqlWhere = 'WHERE 1 = 1 '   
 SET @sqlFrom = 'FROM orden_owner.LogSeguridad la '  
 SET @sqlFrom = @sqlFrom + ' JOIN shared_owner.LogCodigoAccion L on L.IdLogCodigoAccion = la.IdLogCodigoAccion '
    
 IF NOT @Descripcion IS NULL  
 BEGIN  
  SET @Descripcion = '''' + '%'  + @Descripcion + '%' + ''''   
  SET @sqlWhere = @sqlWhere + 'AND la.Descripcion like ' + @Descripcion      
 END  
 IF NOT @IdUsuario IS NULL  
 BEGIN  
  SET @sqlWhere = @sqlWhere + 'AND la.IdUsuario = @IdUsuario '  
 END  
 IF NOT @Codigo IS NULL  
 BEGIN  
	SET @Codigo = '''' + '%'  + @Codigo + '%' + ''''   
	SET @sqlWhere = @sqlWhere + 'AND l.Descripcion like ' + @Codigo
 END  
 IF NOT @FechaDesde IS NULL  
 BEGIN  
  SET @sqlWhere = @sqlWhere + 'AND la.Fecha >= @FechaDesde '  
 END  
 IF NOT @FechaHasta IS NULL  
 BEGIN  
  SET @sqlWhere = @sqlWhere + 'AND la.Fecha <= @FechaHasta '  
 END  
   
 SET @sql = @sql + @sqlFrom + @sqlWhere + '), Total AS (SELECT TOP 1 MAX(TotalRowCount) AS CantidadTotal FROM LogSeguridad) '  
  
 SET @sql = @sql + ' SELECT (SELECT TOP 1 CAST(CantidadTotal AS INT) FROM total ) AS TotalRows, l.IdLogSeguridad,   
  l.IdUsuario AS IdUsuario, u.UserName AS Usuario, C.Descripcion AS Codigo, l.Fecha AS Fecha
  , l.Descripcion As Descripcion 
       FROM   
       (SELECT  ls.IdLogSeguridad FROM LogSeguridad ls ORDER BY ls.IdLogSeguridad OFFSET  @PageSize * (@PageNumber - 1) ROWS  
       FETCH NEXT @PageSize ROWS ONLY) ls       
       INNER JOIN orden_owner.LogSeguridad l ON l.IdLogSeguridad = ls.IdLogSeguridad   
	   INNER JOIN shared_owner.LogCodigoAccion C on l.IdlogCodigoAccion = C.IdLogCodigoAccion
	   INNER JOIN shared_owner.Usuarios u ON u.IdUsuario = l.IdUsuario'  
   

  
 SET @params = N'@FechaDesde DATETIME = NULL,'   
 + '@FechaHasta  DATETIME = NULL,'   
 + '@Descripcion nvarchar(max)= null,'   
 + '@IdUsuario int = NULL,'   
 + '@Codigo nvarchar(max) = NULL,'   
 + '@PageSize BIGINT,'   
 + '@PageNumber BIGINT'   
      
 EXEC sp_executesql @sql  
  ,@params  
  ,@FechaDesde = @FechaDesde  
  ,@FechaHasta = @FechaHasta  
  ,@Descripcion = @Descripcion  
  ,@IdUsuario = @IdUsuario  
  ,@Codigo = @Codigo   
  ,@PageNumber = @PageNumber  
  ,@PageSize = @PageSize   
END