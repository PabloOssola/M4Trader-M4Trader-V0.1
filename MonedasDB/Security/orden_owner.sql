CREATE SCHEMA [orden_owner]
    AUTHORIZATION [orden_schemas_owner];






























































































GO

GRANT UPDATE
ON SCHEMA::[orden_owner] TO [orden_rol];


GO
GRANT SELECT
    ON SCHEMA::[orden_owner] TO [orden_rol];


GO
GRANT INSERT
    ON SCHEMA::[orden_owner] TO [orden_rol];


GO
GRANT EXECUTE
    ON SCHEMA::[orden_owner] TO [orden_rol];


GO
GRANT DELETE
    ON SCHEMA::[orden_owner] TO [orden_rol];
