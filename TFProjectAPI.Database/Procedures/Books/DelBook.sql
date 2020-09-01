CREATE PROCEDURE [AppUser].[DelBook]
	@Id int
AS
BEGIN
	Exec [AppUser].[DelObject] @Id;
	DELETE FROM [Books] Where [Id] = @Id;
END
