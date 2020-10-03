CREATE PROCEDURE [orden_owner].[OPE_ObtenerCantidadOperada]
@IdPersona int,
@IdTiempoLimite int,
@TipoOperacion char, 
@TotalOperado decimal(18,4) output

AS

BEGIN    
 SET NOCOUNT ON     
   
    declare @importeCalculado decimal(18,4)

    SELECT @importeCalculado = coalesce(sum(Cantidad), 0.00)
    FROM [orden_owner].[Operaciones] as o
    WHERE  ((@TipoOperacion = 'C' AND o.IdPersonaComprador = @IdPersona) or (@TipoOperacion = 'V' AND o.IdPersonaVendedor = @idpersona)) 
    AND ((@IdTiempoLimite = 1 AND o.FechaOperacion between DATEADD(Hour, -1, GETDATE()) and GETDATE())  -- ultima hora
            or (@IdTiempoLimite = 2 AND o.FechaOperacion between DATEADD(DAY, -1, GETDATE()) and  GETDATE())) -- ultimo dia

                                                    --    case TipoLimite = 1 then fechaconcertacion between primer dia del mes, ultimo dia del mes
                                                    --else case tipolimite = 2 then fechaconcertacion between primera hora de hoy ultima hora de hoy
                                                    --else case tipolimite = 3  -- ultimosemeste

    
    SELECT @TotalOperado =  @importeCalculado
END