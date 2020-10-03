CREATE PROCEDURE [api_owner].[LOG_CommandInsert]
@IdUsuario		int,
@CommandName	varchar(100),
@Codigo			varchar(15),
@StartDateTime	datetime,
@RequestId		uniqueidentifier,
@Argument		varchar(max),
@IdSesion		uniqueidentifier
AS
BEGIN

INSERT INTO api_owner.LogCommand
           (IdUsuario
           ,CommandName
           ,Codigo
           ,StartDateTime
           ,RequestId
           ,Argument
           ,IdSesion)
     VALUES
           (@IdUsuario
           ,@CommandName
           ,@Codigo
           ,@StartDateTime
           ,@RequestId
           ,@Argument
           ,@IdSesion)

END