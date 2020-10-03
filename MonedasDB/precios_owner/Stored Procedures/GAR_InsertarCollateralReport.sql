CREATE PROCEDURE [precios_owner].[GAR_InsertarCollateralReport] 
 @ClearingHouse VARCHAR(8),
 @Dador VARCHAR(8),
 @Receptor VARCHAR(8),
 @IdMoneda TINYINT,
 @TotalAmount BIGINT,
 @ConsumedAmount BIGINT,
 @ConsumedChips BIGINT,
 @IdCollateralReport INT OUTPUT
                 
AS                 
BEGIN                 
 SET NOCOUNT ON                 

 SELECT @IdCollateralReport = IdCollateralReport
 FROM precios_owner.CollateralReport 
 WHERE ClearingHouse = @ClearingHouse AND Giver = @Dador AND Receiver = @Receptor AND IdCurrency = @IdMoneda

 IF (@IdCollateralReport IS NULL OR @IdCollateralReport = 0)
 BEGIN
	 DECLARE @resultado TABLE (IdCollateralReport INT)

	 INSERT INTO precios_owner.CollateralReport (                 
	  ClearingHouse                
	  , Giver                
	  , Receiver                
	  , IdCurrency
	  , TotalAmount                
	  , ConsumedAmount
	  , ConsumedChips
	 )             
	 OUTPUT Inserted.IdCollateralReport INTO @resultado            
	 VALUES (                 
	  @ClearingHouse                
	  , @Dador                
	  , @Receptor                
	  , @IdMoneda
	  , @TotalAmount              
	  , @ConsumedAmount
	  , @ConsumedChips
	 )
	SELECT @IdCollateralReport = IdCollateralReport FROM @resultado
 END
 ELSE
 BEGIN
	UPDATE precios_owner.CollateralReport 
	SET TotalAmount = @TotalAmount, ConsumedAmount = @ConsumedAmount, ConsumedChips = @ConsumedChips 
	WHERE IdCollateralReport = @IdCollateralReport
 END
END