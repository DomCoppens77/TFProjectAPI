CREATE PROCEDURE [AppUser].[CheckCtry]
	@ISO NVARCHAR(3)
AS
BEGIN
	DECLARE @Cnt INT;
	DECLARE @Cnt2 INT;
	SET @Cnt = [dbo].[SF_CountCtry_Music](UPPER(@ISO));
	SET @Cnt2 = [dbo].[SF_CountCtry_Shop](UPPER(@ISO));

	SET @CNT = @Cnt + @Cnt2;

	SELECT @Cnt;
END
