CREATE PROCEDURE [AppUser].[UpdUser]
	@Id int,
	@LastName varchar(50),
	@FirstName nvarchar(50),
	@Status int
AS
BEGIN
	UPDATE [Users] SET
	[LastName] = @LastName, 
	[FirstName] = @FirstName, 
	[Status] = @Status
	WHERE [Id] = @Id;
	RETURN 0
END