CREATE PROCEDURE [orden_owner].[QRY_SCRN_PORTFOLIO_GRID_MAIN_ALL]        
	@IdUsuario INT=NULL,        
	@IdPortfolio INT,        
	@PageNumber BIGINT=NULL,         
	@PageSize BIGINT=0        
          
AS        
BEGIN         
        DECLARE @fecha datetime = GETDATE()
 ;WITH portfolio AS (        
    SELECT         
     CAST(pro.IdProducto AS VARCHAR) + '_' + CAST(pc.IdMercado as VARCHAR)  + '_' + CAST(pc.IdPlazo as VARCHAR) AS ProductoMercado,        
     pre.IdPrecio,        
     pc.IdProducto,         
     me.IdMercado,                  
     pro.Descripcion		AS ProductoDescripcion,        
     pro.Codigo				AS ProductoCodigo,        
     me.Descripcion			AS MercadoDescripcion,        
     me.Codigo				AS MercadoCodigo,        
     pre.ClosingPrice  AS PrecioApertura,  
     pre.Precio,        
     oferta.PrecioCompra,        
     oferta.CantidadCompra,        
     oferta.PrecioVenta,        
     oferta.CantidadVenta,        
     mo.Codigo				AS  MonedaCodigo,        
     mo.IdMoneda,        
     pc.IdPlazo,        
     COALESCE(pl.Descripcion, '') as Plazo,
	 FechaPrecio = pre.Fecha,
	 ''    AS Sparklines 
    FROM orden_owner.PortfoliosComposicion pc 
	 INNER JOIN orden_owner.Productos pro ON pc.IdProducto = pro.IdProducto AND pro.BajaLogica = 0
	 INNER JOIN shared_owner.Monedas mo on pro.IdMoneda = mo.IdMoneda 
	 INNER JOIN shared_owner.Mercados me on me.IdMercado = pc.IdMercado    
	 INNER JOIN orden_owner.Plazos pl ON pc.IdPlazo = pl.IdPlazo 
	 LEFT JOIN orden_owner.Precios pre ON pre.IdProducto = pc.IdProducto AND pre.IdMercado = pc.IdMercado AND pre.IdPlazo = pc.IdPlazo    
     OUTER APPLY         
     (        
      SELECT          
       ofer.IdMercado,        
       ofer.IdProducto,        
		ofer.Plazo,
		ofer.IdMoneda,        
       MAX(PrecioCompra) PrecioCompra,        
       MAX(CASE ofer.CompraVenta WHEN 'C' THEN ofer.CantidadCompra END) CantidadCompra,        
       MAX(PrecioVenta) PrecioVenta,        
       MAX(CASE ofer.CompraVenta WHEN 'V' THEN ofer.CantidadVenta END) CantidadVenta        
      FROM (        
       SELECT         
			o.CompraVenta,        
			o.IdMercado,         
			o.IdProducto,         
			prod.IdMoneda,
			o.Precio,        
			o.Plazo,        
			MIN(CASE o.CompraVenta WHEN 'C' THEN o.Precio END) OVER (PARTITION BY o.IdMercado, o.IdProducto, o.Plazo) PrecioCompra,        
			MAX(CASE o.CompraVenta WHEN 'V' THEN o.Precio END) OVER (PARTITION BY o.IdMercado, o.IdProducto, o.Plazo) PrecioVenta,        
			CASE o.CompraVenta WHEN 'C' THEN o.Cantidad END CantidadCompra,        
			CASE o.CompraVenta WHEN 'V' THEN o.Cantidad END CantidadVenta        
       FROM         
        orden_owner.Ofertas o        
		INNER JOIN orden_owner.Productos prod on o.IdProducto = prod.IdProducto 
       WHERE         
        o.IdProducto = pc.IdProducto 
		AND o.IdMercado = pc.IdMercado   
		AND o.Plazo = pc.IdPlazo   
		AND prod.IdMoneda = pro.IdMoneda  
        AND o.Precio > 0       
        
      ) ofer 
	  WHERE (ofer.Precio = ofer.PrecioCompra AND ofer.CompraVenta = 'C') 
	  OR (ofer.Precio = ofer.PrecioVenta AND ofer.CompraVenta = 'V')        
      GROUP BY ofer.IdMercado, ofer.IdProducto, ofer.IdMoneda, ofer.Plazo      
     ) oferta           
        
    WHERE 
		(pc.IdPortfolio = @IdPortfolio )  
 )        
        
 SELECT * FROM portfolio;        
END