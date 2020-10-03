/****** ESQUEMA SHARED **********/
CREATE ROLE [dbr_shared] AUTHORIZATION [orden_schemas_owner];
GO

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

/****** ESQUEMA FIX **********/
CREATE SCHEMA [fix_owner]
    AUTHORIZATION [orden_schemas_owner];
GO

CREATE ROLE [dbr_fix] AUTHORIZATION [orden_schemas_owner];

GO


GRANT EXECUTE
    ON SCHEMA::[fix_owner] TO [dbr_fix];
GO

GRANT INSERT
    ON SCHEMA::[fix_owner] TO [dbr_fix];
GO

GRANT SELECT
    ON SCHEMA::[fix_owner] TO [dbr_fix];
GO

GRANT UPDATE
    ON SCHEMA::[fix_owner] TO [dbr_fix];
GO

