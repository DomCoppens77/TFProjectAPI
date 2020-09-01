CREATE PROCEDURE [AppUser].[UpdCurr]
	@Curr NVARCHAR(3),
	@Desc NVARCHAR(100)
AS
BEGIN
	UPDATE [Currency] SET
	[Description] = UPPER(TRIM(@Desc))
	WHERE [Curr] = @Curr;
	RETURN 0
END
