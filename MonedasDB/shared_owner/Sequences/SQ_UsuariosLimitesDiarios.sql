CREATE SEQUENCE [shared_owner].[SQ_UsuariosLimitesDiarios] 
AS INT
 START WITH 1
 INCREMENT BY 1
GO

 GRANT ALTER
    ON OBJECT::[shared_owner].[SQ_UsuariosLimitesDiarios] TO [orden_rol]
    AS [orden_schemas_owner];
GO
