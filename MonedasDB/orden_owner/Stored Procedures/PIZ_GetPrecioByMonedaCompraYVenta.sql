CREATE PROCEDURE [orden_owner].[PIZ_GetPrecioByMonedaCompraYVenta]
@IdMoneda tinyint,
@compraOVenta Char(1),
@Precio Decimal(18,4) OUTPUT 
  
AS

BEGIN    
 SET NOCOUNT ON     
   
   if(@compraOVenta = 'C')
   BEGIN 
		select @Precio = PrecioVenta from orden_owner.pizarra where  IdMoneda = @IdMoneda
   END
   ELSE
   BEGIN
		SELECT @Precio = PrecioCompra from orden_owner.pizarra where  IdMoneda = @IdMoneda
   END
END