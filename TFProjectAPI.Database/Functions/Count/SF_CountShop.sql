CREATE FUNCTION [dbo].[SF_CountShop]
(
	@Id int
)
RETURNS INT
AS
BEGIN
	DECLARE @Cnt int
	SELECT @Cnt = count(*) from [Object] WHERE [ShopId] = @Id; 
	RETURN @Cnt;
END
