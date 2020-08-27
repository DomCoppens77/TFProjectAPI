CREATE FUNCTION [dbo].[SF_CountMusicType]
(
	@Id int
)
RETURNS INT
AS
BEGIN
	DECLARE @Cnt int
	SELECT @Cnt = count(*) from [Music] WHERE [MTypeId] = @Id; 
	RETURN @Cnt;
END
