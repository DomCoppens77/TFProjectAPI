CREATE PROCEDURE [AppUser].[CheckMusicType]
	@Id int
AS
BEGIN
	DECLARE @Cnt INT;
	SET @Cnt = [dbo].[SF_CountMusicType](@Id);
	RETURN @Cnt;
END

