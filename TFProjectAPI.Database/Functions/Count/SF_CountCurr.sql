CREATE FUNCTION [dbo].[SF_CountCurr]
(
	@Curr nvarchar(3)
)
RETURNS INT
AS
BEGIN
	DECLARE @Cnt int;
	SELECT @Cnt = count(*) from [Object] WHERE [Object].[Curr] = UPPER(@Curr); 
	RETURN (@Cnt);
END
