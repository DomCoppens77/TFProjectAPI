CREATE PROCEDURE [AppUser].[DelCurr]
	@Curr NVARCHAR(3)
AS
BEGIN
	if ([dbo].[SF_CountCurr](@Curr)) = 0
	DELETE FROM [Currency] Where [Curr] = @Curr;
END

