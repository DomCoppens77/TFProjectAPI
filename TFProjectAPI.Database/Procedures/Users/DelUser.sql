CREATE PROCEDURE [AppUser].[DelUser]
	@Id int
AS
BEGIN
	DELETE FROM [Users] Where [Id] = @Id;
	RETURN 0
END