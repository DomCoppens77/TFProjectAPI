CREATE PROCEDURE [AppUser].[DelObject]
	@Id int
AS
BEGIN
		DELETE FROM [Object] Where [Id] = @Id;
END

