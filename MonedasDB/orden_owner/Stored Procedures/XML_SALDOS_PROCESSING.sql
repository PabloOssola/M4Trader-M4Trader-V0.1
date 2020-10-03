CREATE PROCEDURE [orden_owner].[XML_SALDOS_PROCESSING]      
 @CodCliente varchar(18),      
 @CodEmpresa varchar(18),      
 @TipoProducto varchar(50),      
 @CodigoProducto varchar(10)=null,      
 @DescripcionProducto varchar(200)=null,      
 @Cantidad decimal(18,4)=null,    
 @Precio decimal(18,4)=null,    
 @Monto decimal(18,4),      
 @Moneda int      
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
    
 DECLARE @IdTipoProducto TINYINT;    
 DECLARE @IdPersona TINYINT;    
 DECLARE @IdEmpresa TINYINT;    
    
 SELECT TOP(1) @IdTipoProducto =IdTipoProducto FROM orden_owner.TiposProducto WHERE Descripcion = @TipoProducto    
  
 
SELECT @IdPersona = P.IdParty, @IdEmpresa = E.IdPartyFather
FROM shared_owner.Parties P
INNER JOIN shared_owner.PartiesHierarchy E on E.IdPartySon = P.IdParty
INNER JOIN shared_owner.Parties PP on E.IdPartyFather = PP.IdParty
WHERE P.MarketCustomerNumber = @CodCliente
and PP.MarketCustomerNumber = @CodEmpresa
  
IF(@IdPersona is not null)  
BEGIN
 INSERT INTO [orden_owner].[Saldos]    
           (    
            [IdPersona]    
           --,[IdEmpresa]    
           ,[IdTipoProducto]    
           --,[CodigoProducto]    
           --,[DescripcionProducto]       
           ,[Importe]    
           ,[idMoneda])    
     VALUES    
           (    
            @IdPersona,    
            --@IdEmpresa,    
            @IdTipoProducto,    
            --ISNULL(@CodigoProducto,''),    
            --ISNULL(@DescripcionProducto,''),     
            @Monto,    
            @Moneda)    
	END
END


