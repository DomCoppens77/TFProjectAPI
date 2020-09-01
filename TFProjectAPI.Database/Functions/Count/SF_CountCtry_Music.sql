CREATE FUNCTION [dbo].[SF_CountCtry_Music]
(
	@ISO nvarchar(2)
)
RETURNS INT
AS
BEGIN
	DECLARE @Cnt int;
	SELECT @Cnt = count(*) from [Music] WHERE [Music].[Ctry] = UPPER(@ISO); 
	RETURN (@Cnt);
END
