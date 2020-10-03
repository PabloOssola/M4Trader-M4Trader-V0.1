CREATE PROCEDURE [orden_owner].[USER_InsertarCustomizacionUsuario]
	@IdUsuario INT,
	@Codigo varchar(50),
	@Valor text
AS
BEGIN

   DECLARE @IdCustomizacionUsuario INT
   DECLARE @ptrval binary(16) 
   
   SELECT @IdCustomizacionUsuario = IdCustomizacionUsuario 
   FROM [shared_owner].[CustomizacionUsuario]
   WHERE IdUsuario = @IdUsuario
   AND Codigo = @Codigo

   
   IF (@IdCustomizacionUsuario IS NULL)
   BEGIN
   	INSERT INTO [shared_owner].[CustomizacionUsuario] (
   		[IdUsuario],
   		[Codigo],
   		[Valor]
   	) VALUES (
   		@IdUsuario,
   		@Codigo,
   		@Valor
   	)
   	   END
   ELSE
   BEGIN
      SELECT @ptrval = TEXTPTR(Valor)
      FROM [shared_owner].[CustomizacionUsuario]
      WHERE IdCustomizacionUsuario = @IdCustomizacionUsuario
    
      IF  (SELECT TEXTVALID ('[shared_owner].[CustomizacionUsuario].Valor', @ptrval)) = 1
      BEGIN
         WRITETEXT [shared_owner].[CustomizacionUsuario].Valor @ptrval @Valor   
      END
   
   END

END