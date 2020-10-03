CREATE SCHEMA [precios_owner]
    AUTHORIZATION [orden_schemas_owner];








GO


GRANT EXECUTE
    ON SCHEMA::[precios_owner] TO [dbr_precios];
GO

GRANT INSERT
    ON SCHEMA::[precios_owner] TO [dbr_precios];
GO

GRANT SELECT
    ON SCHEMA::[precios_owner] TO [dbr_precios];
GO

GRANT UPDATE
    ON SCHEMA::[precios_owner] TO [dbr_precios];
GO

