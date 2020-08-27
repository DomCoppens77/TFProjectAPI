CREATE PROCEDURE [dbo].[UpdObject]
	@ID int,
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
	@Comment2 NVARCHAR(255)
AS
BEGIN
	UPDATE [Object] SET

	[Price]    = @Price, 
	[Curr]     = trim(@Curr), 
	[ShopId]   = @ShopId, 
	[Date]     = @Date, 
	[TypeId]   = @OTypeId, 
	[Signed]   = @Signed,  
	[SignedBy] = trim(@SignedBy), 
	[EAN]      = trim(@EAN), 
	[EAN_EXT]  = trim(@EAN_EXT), 
	[Comment1] = trim(@Comment1), 
	[Comment2] = trim(@Comment2)
	WHERE [Id] = @ID;
	RETURN 0
END
