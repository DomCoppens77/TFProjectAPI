CREATE PROCEDURE [AppUser].[UpdCtry]
	@ISO NVARCHAR(2),
	@Ctry NVARCHAR(20),
	@IsEU BIT
AS
BEGIN
	UPDATE [Country] SET
	[Ctry] = trim(@Ctry),
	[IsEU] = @IsEU
	WHERE [ISO] = @ISO;
END
