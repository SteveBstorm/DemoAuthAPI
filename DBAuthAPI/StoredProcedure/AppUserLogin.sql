CREATE PROCEDURE [dbo].[AppUserLogin]
	@email VARCHAR(50),
	@passwd VARCHAR(50)
AS 
BEGIN
	DECLARE @salt VARCHAR(100)
	DECLARE @id INT

	SELECT @id = Id FROM AppUser WHERE Email = @email
	
	SELECT @salt = SaltValue FROM AppSalt WHERE UserId = @id

	DECLARE @hash VARBINARY(64)
	SET @hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @passwd, @Salt));


	DECLARE @validId INT
	
	SELECT @validId = Id FROM AppUser WHERE Email = @email AND Passwd = @hash

	IF(@validId = null) 
	BEGIN
		RAISERROR (15600,-1,-1, 'sp_login');
	END
	ELSE
	BEGIN
		SELECT * FROM V_AppUser WHERE Id = @validId 
	END
END
