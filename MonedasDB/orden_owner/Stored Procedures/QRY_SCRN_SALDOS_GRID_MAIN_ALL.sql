CREATE PROCEDURE [orden_owner].[QRY_SCRN_SALDOS_GRID_MAIN_ALL] 
	@IdUsuario      INT         = NULL,   
	@IdPersona INT         = NULL,   
	@IdTipoProducto TINYINT     = NULL,   
	@CodigoProducto VARCHAR(10) = NULL,   
	@PageNumber     BIGINT      = 1,   
	@PageSize       BIGINT      = 10  
AS  
     BEGIN  
         DECLARE @IdPersonaINT INT= NULL;  
		 
		 IF(@IdPersona IS NULL)
		 BEGIN
         IF EXISTS  
         (  
             SELECT 1  
             FROM shared_owner.Usuarios  
             WHERE IdUsuario = @IdUsuario  
         )  
             BEGIN  
                 SELECT @IdPersonaINT = IdPersona  
                 FROM shared_owner.Usuarios  
                 WHERE IdUsuario = @IdUsuario;  
             END
		 END
		 ELSE
		 BEGIN 
			SET @IdPersonaINT = @IdPersona
		 END;
		 
         WITH Consulta  
              AS (SELECT IdSaldo,   
                         IdCliente = SL.IdPersona,   
                         TipoProducto = ISNULL(TP.Descripcion, ''),   
                         --CodigoProducto,   
                         --DescripcionProducto,    
                         importe,   
                         m.Descripcion as Moneda,   
                         TotalRows = COUNT(1) OVER(),   
                         NumeroCuenta,   
                         TipoCuenta = ISNULL(TC.Descripcion, ''),   
                         p.Name AS NombrePersona
                  FROM orden_owner.Saldos sl WITH(NOLOCK)  
                       JOIN shared_owner.Parties P ON P.IdParty = sl.IdPersona
                       JOIN orden_owner.TiposProducto TP ON TP.IdTipoProducto = SL.IdTipoProducto  
                       JOIN shared_owner.Monedas as m on m.idmoneda = sl.Idmoneda
                       LEFT JOIN orden_owner.TiposCuenta TC ON TC.IdTipoCuenta = SL.IdTipoCuenta  
                  
				  WHERE
						(@IdPersonaINT IS NULL or sl.IdPersona = @IdPersonaINT) 
                        AND (@IdTipoProducto IS NULL  
                            OR sl.IdTipoProducto = @IdTipoProducto)  
                        --AND (@CodigoProducto IS NULL  
                        --    OR sl.CodigoProducto = '%'+@CodigoProducto+'%')  
                  ORDER BY sl.IdSaldo ASC  
                  OFFSET @PageSize * (@PageNumber - 1) ROWS FETCH NEXT @PageSize ROWS ONLY)  

              SELECT *  
              FROM Consulta;  
     END;
GO

