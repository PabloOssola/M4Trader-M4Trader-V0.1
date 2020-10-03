CREATE SEQUENCE [orden_owner].[SQ_Precios]
    AS SMALLINT
    START WITH 1
    INCREMENT BY 1;
GO

GRANT ALTER
    ON OBJECT::[orden_owner].[SQ_Precios] TO [orden_rol]
    AS [orden_schemas_owner];
GO
