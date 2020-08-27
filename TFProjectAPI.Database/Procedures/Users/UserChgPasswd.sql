CREATE PROCEDURE [AppUser].[UserChgPasswd]
	@Email   NVARCHAR(320),
	@OldPasswd NVARCHAR(20),
	@Passwd  NVARCHAR(20)
AS
BEGIN
	if (SELECT count(*) from [Users] where [Email] = @Email and [Passwd] = HASHBYTES('SHA2_512', [dbo].[GetPreSalt]() + @OldPasswd + [dbo].[GetPostSalt]()) and [Active] = 1) > 0 
		UPDATE [Users] 
			SET	[Passwd] = HASHBYTES('SHA2_512', [dbo].[GetPreSalt]() + @Passwd + [dbo].[GetPostSalt]())
			WHERE [Email] = @Email;
END
