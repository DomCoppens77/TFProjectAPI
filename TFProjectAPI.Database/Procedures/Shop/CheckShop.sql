CREATE PROCEDURE [AppUser].[CheckShop]
	@Id int
AS
BEGIN
	DECLARE @Cnt INT;
	SET @Cnt = [dbo].[SF_CountShop](@Id);
	RETURN @Cnt;
END
