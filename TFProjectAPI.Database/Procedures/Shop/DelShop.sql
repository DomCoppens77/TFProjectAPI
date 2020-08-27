CREATE PROCEDURE [AppUser].[DelShop]
	@Id int
AS
BEGIN
	DECLARE @cnt int
	/*
	 if (SELECT count(*) from [Object] WHERE [ShopId] = @Id) = 0; /*   Same than [AppUser].[CheckShop]*/
	*/
	if ([dbo].[SF_CountShop](@Id)) = 0 
		DELETE FROM [Shop] Where [Id] = @Id;
END
