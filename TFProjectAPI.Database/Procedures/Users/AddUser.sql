CREATE PROCEDURE [AppUser].[AddUser]
	@FirstName NVARCHAR(50),
	@LastName  NVARCHAR(50),
	@Email     NVARCHAR(320),
	@Passwd    NVARCHAR(20)
AS
BEGIN
	Insert into [Users]([FirstName], [LastName], [Email], [Passwd]) 
    output inserted.Id
    values(@FirstName, @LastName, @Email, HASHBYTES('SHA2_512', [dbo].[GetPreSalt]() + @Passwd + [dbo].[GetPostSalt]()));
END


