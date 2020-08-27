CREATE PROCEDURE [AppUser].[CheckCurr]
	@Curr NVARCHAR(3)
AS
BEGIN
	DECLARE @Cnt INT;
	SET @Cnt = [dbo].[SF_CountCurr](@Curr);
	RETURN @Cnt;
END
