CREATE PROCEDURE [dbo].[spHashingPassword]
	@Password VARCHAR ,
	@Username VARCHAR
AS
BEGIN
	DECLARE	@PassHached VARBINARY
	UPDATE [Users]	
	SET @PassHached = HASHBYTES('SHA2_256', @Password)
	WHERE Username LIKE @Username AND HashPassword LIKE @Password;
END
