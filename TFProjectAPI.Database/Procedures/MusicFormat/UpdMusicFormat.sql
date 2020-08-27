CREATE PROCEDURE [AppUser].[UpdMusicFormat]
	@Id int,
	@Name varchar(20)
AS
BEGIN
	UPDATE [MusicFormat] SET
	[Name] = trim(@Name)
	WHERE [Id] = @Id;
	RETURN 0
END
