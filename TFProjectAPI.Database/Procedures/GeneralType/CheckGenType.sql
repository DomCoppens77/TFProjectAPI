CREATE PROCEDURE [AppUser].[CheckGenType]
	@Id int
AS
BEGIN
	DECLARE @Cnt INT;
	SET @Cnt = [dbo].[SF_CountGenType](@Id);
	SELECT @Cnt;
END