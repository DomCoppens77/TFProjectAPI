CREATE FUNCTION [dbo].[SF_CountGenType]
(
	@Id int
)
RETURNS INT
AS
BEGIN
	DECLARE @Cnt int
	SELECT @Cnt = count(*) from [Object] WHERE [TypeId] = @Id; 
	RETURN @Cnt;
END

