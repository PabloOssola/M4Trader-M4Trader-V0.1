CREATE PROCEDURE [orden_owner].[OPE_CrearOperacion]
@IdPersonaComprador int,
@IdPersonaVendedor int,
@Cantidad decimal(18,2),
@Monto decimal(18,2),
@Precio decimal(18,4),
@NroOperacion nvarchar(25),
@FechaOperacion datetime,
@IdMonedaCompra tinyint,
@IdMonedaVenta tinyint, 
@IdPropietario int output

AS

BEGIN    
 SET NOCOUNT ON     
   DECLARE @resultado TABLE (IdOperacion int)  

   INSERT INTO [orden_owner].[Operaciones]
           ([IdPersonaComprador]
           ,[IdPersonaVendedor]
           ,[Cantidad]
           ,[Monto]
           ,[Precio]
           ,[NroOperacion]
           ,[FechaOperacion]
           ,[IdMonedaCompra]
           ,[IdMonedaVenta])
     OUTPUT Inserted.IdOperacion INTO @resultado 
     VALUES(
                @IdPersonaComprador,
                @IdPersonaVendedor,
                @Cantidad,
                @Monto,
                @Precio,
                @NroOperacion,
                @FechaOperacion,
                @IdMonedaCompra,
                @IdMonedaVenta 
            ) 
    SELECT @IdPropietario = r.IdOperacion from @resultado r    
END