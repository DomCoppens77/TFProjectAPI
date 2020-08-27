CREATE PROCEDURE [AppUser].[DelMusic]
	@Id int
AS
BEGIN
	Exec [AppUser].[DelObject] @Id;
	DELETE FROM [Music] Where [Id] = @Id;
END
