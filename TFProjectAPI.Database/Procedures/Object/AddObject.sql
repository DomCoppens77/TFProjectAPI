CREATE PROCEDURE [dbo].[AddOject]
	
	@Price FLOAT,
	@Curr NVARCHAR(3),
	@ShopId INT,
	@Date DATETIME2,
	@OTypeId INT,
    @Signed BIT, 
	@SignedBy NVARCHAR(100),
	@EAN NVARCHAR(15),
	@EAN_EXT NVARCHAR(15),
	@Comment1 NVARCHAR(255),
	@Comment2 NVARCHAR(255),
	@ID INT output
AS
BEGIN
	Insert into [Object] ([Price], [Curr], [ShopId], [Date], [TypeId], [Signed], [SignedBy], [EAN], [EAN_EXT], [Comment1], [Comment2]) 
    values(@Price, @Curr, @ShopId, @Date, @OTypeId, @Signed, trim(@SignedBy), trim(@EAN), trim(@EAN_EXT), trim(@Comment1), trim(@Comment2) );
	set @ID = @@IDENTITY;
END