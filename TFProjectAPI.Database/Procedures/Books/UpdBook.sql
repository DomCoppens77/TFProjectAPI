CREATE PROCEDURE [AppUser].[UpdBook]
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
	@Comment2 NVARCHAR(255),

	@Serie      NVARCHAR(50),
	@Title      NVARCHAR(50),
	@Writer1    NVARCHAR(30),
	@Writer2    NVARCHAR(30),
	@Language   NVARCHAR(2),
	@Edition    NVARCHAR(20),
	@Format     NVARCHAR(20),
	@Number     INTEGER,
	@Pages      INTEGER ,
	@YEAR       INTEGER ,
	@FirstPrint bit
AS
BEGIN

	exec [dbo].[UpdObject] @ID, @Price, @Curr, @ShopId, @Date, @OTypeId, @Signed, @SignedBy, @EAN, @EAN_EXT, @Comment1, @Comment2;

	UPDATE [Books] SET
	[Serie]      = TRIM(@Serie),          
	[Title]      = TRIM(@Title),          
	[Writer1]    = TRIM(@Writer1),        
	[Writer2]    = TRIM(@Writer2),        
	[Language]   = UPPER(TRIM(@Language)),
	[Edition]    = TRIM(@Edition),        
	[Format]     = TRIM(@Format),         
	[Number]     = @Number,               
	[Pages]      = @Pages,                
	[YEAR]       = @YEAR,                 
	[FirstPrint] = @FirstPrint            
	WHERE [Id]  = @Id;
	RETURN 0
END
