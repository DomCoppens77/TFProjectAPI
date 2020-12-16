CREATE PROCEDURE [AppUser].[UserResetPasswd]
	@Email   NVARCHAR(320),
	@SecretAnswer NVARCHAR(20),
	@Passwd  NVARCHAR(20)
AS
BEGIN
	if (SELECT count(*) from [Users] where [Email] = @Email and [SecretAnswer] = [dbo].[GetHashPasswd](@SecretAnswer) and [Active] = 1) > 0 
	UPDATE [Users] 
		SET	[Passwd] = [dbo].[GetHashPasswd](@Passwd)
		WHERE [Email] = @Email;
END
