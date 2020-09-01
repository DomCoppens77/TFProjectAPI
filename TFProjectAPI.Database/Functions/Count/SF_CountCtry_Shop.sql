CREATE FUNCTION [dbo].[SF_CountCtry_Shop]
(
	@ISO nvarchar(2)
)
RETURNS INT
AS
BEGIN
	DECLARE @Cnt int;
	SELECT @Cnt = count(*) from [Shop] WHERE [Shop].[Country] = UPPER(@ISO); 
	RETURN (@Cnt);
END