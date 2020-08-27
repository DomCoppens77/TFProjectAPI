CREATE PROCEDURE [AppUser].[CheckUser]
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
	if (SELECT count(*) from [Users] where [Email] = @Email and [Passwd] = HASHBYTES('SHA2_512', [dbo].[GetPreSalt]() + @Passwd + [dbo].[GetPostSalt]()) and [Active] = 1) > 0 
	  exec [AppUser].[UpdUserConnection] @EMAIL;

	SELECT [Id], [LastName], [FirstName], [Email], [Active], [Status], [ConnectionCount], [ConnectionLast]  
	  from [Users] where [Email] = @Email and [Passwd] = HASHBYTES('SHA2_512', [dbo].[GetPreSalt]() + @Passwd + [dbo].[GetPostSalt]()) and [Active] = 1;
