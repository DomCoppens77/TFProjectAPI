CREATE PROCEDURE [AppUser].[DelCurr]
	@Curr NVARCHAR(3)
AS
BEGIN
	
	/* if (SELECT count(*) from [Object] WHERE [Curr] = @Curr) = 0  /* Same Code in [AppUser].[CheckCurr] */ 
	*/
	if ([dbo].[SF_CountCurr](@Curr)) = 0
	DELETE FROM [Currency] Where [Curr] = @Curr;
END

