CREATE SCHEMA [shared_owner]
    AUTHORIZATION [orden_schemas_owner];
GO


GRANT EXECUTE
    ON SCHEMA::[shared_owner] TO [dbr_shared];
GO

GRANT INSERT
    ON SCHEMA::[shared_owner] TO [dbr_shared];
GO

GRANT SELECT
    ON SCHEMA::[shared_owner] TO [dbr_shared];
GO

GRANT UPDATE
    ON SCHEMA::[shared_owner] TO [dbr_shared];
GO

GRANT DELETE
    ON SCHEMA::[shared_owner] TO [dbr_shared];
GO