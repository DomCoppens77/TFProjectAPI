CREATE PROCEDURE [AppUser].[UserChgPasswd]
	@Email   NVARCHAR(320),
	@OldPasswd NVARCHAR(20),
	@Passwd  NVARCHAR(20)
AS
BEGIN
	if (SELECT count(*) from [Users] where [Email] = @Email and [Passwd] = [dbo].[GetHashPasswd](@OldPasswd) and [Active] = 1) > 0 
		UPDATE [Users] 
			SET	[Passwd] = [dbo].[GetHashPasswd](@Passwd)
			WHERE [Email] = @Email;
END
