CREATE PROCEDURE [orden_owner].[DMA_AgregarPortfolioAUsuario]
@Username varchar(100),
@Portfolio varchar(5)
AS
BEGIN
	SET NOCOUNT ON;
	
	begin tran
	BEGIN TRY
	

	insert into orden_owner.PortfolioUsuario(IdUsuario, IdPortfolio, PorDefecto)
	select IdUsuario, p.IdPortfolio, 0 from shared_owner.Usuarios u,  orden_owner.Portfolios p
	where IdUsuario = (select IdUsuario from shared_owner.Usuarios where Username = @Username)
	and p.Codigo = @Portfolio
	and not exists (select * from orden_owner.PortfolioUsuario where IdUsuario = u.IdUsuario and IdPortfolio = p.IdPortfolio)

	
	COMMIT	
	END TRY

	BEGIN CATCH
		SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage; 
		ROLLBACK
		RAISERROR('Se produjo algun error en el script [orden_owner].[[DMA_AgregarPortfolioAUsuario]]',16,10)
	END CATCH	

END