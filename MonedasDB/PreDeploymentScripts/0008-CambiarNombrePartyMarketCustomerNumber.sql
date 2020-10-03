IF (1 > (SELECT COUNT(1) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'shared_owner' AND TABLE_NAME='Parties' AND COLUMN_NAME = 'MarketCustomerNumber'))
BEGIN
  EXEC sp_RENAME '[shared_owner].[Parties].[CustomerNumber]', 'MarketCustomerNumber', 'COLUMN'
END