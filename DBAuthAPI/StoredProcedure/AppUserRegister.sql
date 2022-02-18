CREATE PROCEDURE [dbo].[AppUserRegister]
	@email VARCHAR(50),
	@passwd VARCHAR(50),
	@nickname VARCHAR(50)

AS 
BEGIN
	SET NOCOUNT ON
	DECLARE @salt VARCHAR(100)
	SET @salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @hashpwd VARBINARY(64)
	SET @hashpwd = HASHBYTES('SHA2_512', CONCAT(@Salt, @passwd, @Salt));

	DECLARE @currentId INT

	INSERT INTO AppUser (Email, Passwd, NickName) VALUES (@email, @hashpwd, @nickname)

	SELECT @currentId = Id FROM AppUser WHERE Email = @email

	INSERT INTO AppSalt (SaltValue, UserId) VALUES (@salt, @currentId)
END