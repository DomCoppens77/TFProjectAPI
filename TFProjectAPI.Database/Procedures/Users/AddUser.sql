CREATE PROCEDURE [AppUser].[AddUser]
	@FirstName    NVARCHAR(50),
	@LastName     NVARCHAR(50),
	@Email        NVARCHAR(320),
	@Passwd       NVARCHAR(20),
	@SecretAnswer NVARCHAR(20),
	@Avatar       NVARCHAR(MAX)
AS
BEGIN
	Insert into [Users]([FirstName], [LastName], [Email], [Passwd], [SecretAnswer],[Avatar]) 
    output inserted.Id
    values(@FirstName, @LastName, @Email, [dbo].[GetHashPasswd](@Passwd),[dbo].[GetHashPasswd](@SecretAnswer),@Avatar);
END


