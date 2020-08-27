CREATE PROCEDURE [AppUser].[DelMusicFormat]
	@Id int
AS
BEGIN
/*
	if (SELECT count(*) from [Music] WHERE [FormatId] = @Id) = 0 /* Same Code in [AppUser].[CheckMusicFormat]*/
*/
	if ([dbo].[SF_CountMusicFormat](@Id)) = 0
		DELETE FROM [MusicFormat] Where [Id] = @Id;
END
