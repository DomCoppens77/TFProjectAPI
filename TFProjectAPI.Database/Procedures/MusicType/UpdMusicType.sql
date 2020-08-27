CREATE PROCEDURE [AppUser].[UpdMusicType]
	@Id int,
	@Name varchar(20)
AS
BEGIN
	UPDATE [MusicType] SET
	[Name] = trim(@Name)
	WHERE [Id] = @Id;
	RETURN 0
END

