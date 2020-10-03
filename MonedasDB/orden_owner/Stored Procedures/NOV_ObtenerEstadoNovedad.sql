CREATE PROCEDURE [orden_owner].[NOV_ObtenerEstadoNovedad]
@IdNovedadDeTransferencia int,
@IdEstado int output
 
AS

BEGIN    
 SET NOCOUNT ON     
    SELECT @IdEstado = IdEstado 
        from orden_owner.NovedadesDeTransferencias 
        where IdNovedadTransferenciaFondo = @IdNovedadDeTransferencia
END