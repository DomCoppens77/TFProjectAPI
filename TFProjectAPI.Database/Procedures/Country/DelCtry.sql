CREATE PROCEDURE [AppUser].[DelCtry]
	@ISO NVARCHAR(2)
AS
BEGIN
	if ([dbo].[SF_CountCtry_Music](@ISO)) = 0
		if ([dbo].[SF_CountCtry_Shop](@ISO)) = 0
			DELETE FROM [Country] Where [ISO] = @ISO;
END
