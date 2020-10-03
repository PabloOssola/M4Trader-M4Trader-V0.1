CREATE PROCEDURE [orden_owner].[NOV_CrearNovedad]
@CodigoUsuario nvarchar(20),
@Fecha datetime,
@CBUOrigen nvarchar(22),
@CBUDestino nvarchar(22),
@BancoReceptor nvarchar(50),
@IdMoneda tinyint,
@Importe decimal(18,2),
@Comentarios nvarchar(50), 
@Comprobante image, 
@IdNovedadTransferenciaFondo int output
 
AS

BEGIN    
 SET NOCOUNT ON     
   DECLARE @resultado TABLE (IdNovedadTransferenciaFondo int)   

    INSERT INTO [orden_owner].[NovedadesDeTransferencias]
			   ( [CodigoUsuario]
			   ,[Fecha]
			   ,[CBUOrigen]
			   ,[IdMoneda]
			   ,[BancoReceptor]
			   ,[CBUDestino]
			   ,[Importe]
			   ,[Comprobante]
			   ,[Comentarios]
               ,[IdEstado]) 
     OUTPUT Inserted.IdNovedadTransferenciaFondo INTO @resultado 
     VALUES
           ( 
			@CodigoUsuario
           ,@Fecha 
           ,@CBUOrigen 
           ,@IdMoneda 
           ,@BancoReceptor 
           ,@CBUDestino 
           ,@Importe 
           ,@Comprobante 
           ,@Comentarios
           ,1)
    SELECT @IdNovedadTransferenciaFondo = r.IdNovedadTransferenciaFondo from @resultado r    
END