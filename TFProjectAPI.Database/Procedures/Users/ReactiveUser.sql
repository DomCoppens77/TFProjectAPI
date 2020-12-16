CREATE PROCEDURE [AppUser].[ReactiveUser]
	@Id int
	--@Email NVARCHAR(320),
	--@Passwd NVARCHAR(20)
AS
BEGIN
	--if (SELECT count(*) from [Users] where [Email] = @Email and [Passwd] = [dbo].[GetHashPasswd](@Passwd) and [Active] = 1 AND [Status] = 0) > 0 
	UPDATE [Users] SET
	[Active] = 1
	WHERE [Id] = @Id;
END
