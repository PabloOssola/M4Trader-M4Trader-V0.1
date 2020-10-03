CREATE SCHEMA [api_owner]
    AUTHORIZATION [orden_schemas_owner];

	GO

GRANT UPDATE
ON SCHEMA::[api_owner] TO [orden_rol];


GO
GRANT SELECT
    ON SCHEMA::[api_owner] TO [orden_rol];


GO
GRANT INSERT
    ON SCHEMA::[api_owner] TO [orden_rol];


GO
GRANT EXECUTE
    ON SCHEMA::[api_owner] TO [orden_rol];


GO
GRANT DELETE
    ON SCHEMA::[api_owner] TO [orden_rol];