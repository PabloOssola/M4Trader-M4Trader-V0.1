CREATE PROCEDURE [orden_owner].[OPE_CrearRestricciones]
@FechaOperacion datetime,
@Tope decimal(18,2),
@TipoOperacion char,
@IdPersona int,
@IdTiempoLimite int  

AS

BEGIN    
 SET NOCOUNT ON      

    declare @importeCalculado decimal(18,4)

    SELECT @importeCalculado = coalesce(sum(Cantidad), 0.00)
    FROM [orden_owner].[Operaciones] as o
    WHERE  ((@TipoOperacion = 'C' AND o.IdPersonaComprador = @IdPersona) or (@TipoOperacion = 'V' AND o.IdPersonaVendedor = @idpersona)) 
    AND ((@IdTiempoLimite = 1 AND o.FechaOperacion between DATEADD(Hour, -1, GETDATE()) and GETDATE())  -- ultima hora
            or (@IdTiempoLimite = 2 AND o.FechaOperacion between DATEADD(DAY, -1, GETDATE()) and  GETDATE())) -- ultimo dia


    if(@importecalculado = @Tope)
    begin
        declare @FechaHasta datetime

        SELECT @FechaHasta = CASE @IdTiempoLimite WHEN 1 THEN DATEADD(Hour, 1, GETDATE()) ELSE DATEADD(DAY, 1, GETDATE()) END

       INSERT INTO [orden_owner].[usuarioBloqueadoParaOperar]
               ([IdPersona]
               ,[TipoOperacion]
               ,[FechaBloqueadoDesde]
               ,[FechaBloqueadoHasta]) 
         VALUES(
                    @IdPersona,
                    @TipoOperacion,
                    Getdate(),
                    @FechaHasta) 
    end
END