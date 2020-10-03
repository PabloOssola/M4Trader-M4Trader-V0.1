CREATE PROCEDURE orden_owner.QRY_SCRN_DETALLES_AUDITORIA
@IdLogAuditoria INT
AS
BEGIN 
    SET NOCOUNT ON;
    
SELECT ValorOriginal, ValorNuevo
from shared_owner.LogAuditoria la
    WHERE   
		  la.IdLogAuditoria = @IdLogAuditoria
END
GO