CREATE PROCEDURE [shared_owner].[SESSION_DELETE]
AS
  BEGIN
        DELETE shared_owner.Sesiones
        WHERE  FechaFinalizacion < GETDATE()
  END