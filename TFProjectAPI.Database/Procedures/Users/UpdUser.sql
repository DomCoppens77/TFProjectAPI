CREATE PROCEDURE [AppUser].[UpdUser]
	@Id int,
	@LastName varchar(50),
	@FirstName nvarchar(50),
	@Status int,
	@Avatar  NVARCHAR(MAX)
AS
BEGIN
	UPDATE [Users] SET	[LastName] = @LastName 
	,[FirstName] = @FirstName
	,[Status] = @Status
	,[Avatar] = @Avatar
	WHERE [Id] = @Id;

	-- if (SELECT count(*) from [AppUser].[V_Users] where [Email] = @Email) = 0
	-- UPDATE [Users] SET [Email] = @Email WHERE [Id] = @Id;

END