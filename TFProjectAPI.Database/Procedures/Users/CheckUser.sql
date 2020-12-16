CREATE PROCEDURE [AppUser].[CheckUser]
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
BEGIN
	if (SELECT count(*) from [Users] where [Email] = @Email and [Passwd] = [dbo].[GetHashPasswd](@Passwd) and [Active] = 1 ) > 0 
		exec [AppUser].[UpdUserConnection] @EMAIL;

	SELECT [Id], [LastName], [FirstName], [Email], [Active], [Status], [ConnectionCount], [ConnectionLast],[Avatar]  
	  from [Users] where [Email] = @Email and [Passwd] = [dbo].[GetHashPasswd](@Passwd) and [Active] = 1;
END