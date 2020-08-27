CREATE FUNCTION [dbo].[SF_CountMusicFormat]
(
	@Id int
)
RETURNS INT
AS
BEGIN
	DECLARE @Cnt int
	SELECT @Cnt = count(*) from [Music] WHERE [FormatId] = @Id; 
	RETURN @Cnt;
END
