CREATE PROCEDURE [AppUser].[DelMusicType]
	@Id int
AS
BEGIN
/*
	if (SELECT count(*) from [Music] WHERE [MTypeId] = @Id) = 0  /* Same Code in [AppUser].[CheckMusicType] */ 
*/
	if ([dbo].[SF_CountMusicType](@Id)) = 0
	DELETE FROM [MusicType] Where [Id] = @Id;
	
END
