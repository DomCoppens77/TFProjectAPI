CREATE PROCEDURE [AppUser].[UpdMusic]
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

	@Band NVARCHAR(50),
	@Title NVARCHAR(50),
	@YEAR INTEGER,
	@TRACKS NVARCHAR(100),
	@NbCDs INTEGER,
	@NbDvds INTEGER,
	@NbLps INTEGER,
	@MTypeId INTEGER,
	@FormatId INTEGER,
	@SerialNbr NVARCHAR(50),
	@Ctry NVARCHAR(2)
AS
BEGIN

	exec [dbo].[UpdObject] @ID, @Price, @Curr, @ShopId, @Date, @OTypeId, @Signed, @SignedBy, @EAN, @EAN_EXT, @Comment1, @Comment2;

	UPDATE [Music] SET
	[Band]      = trim(@Band),
	[Title]     = trim(@Title),
	[YEAR]      = @YEAR,
	[TRACKS]    = trim(@TRACKS),
	[NbCDs]     = @NbCDs,
	[NbDvds]    = @NbDvds,
	[NbLps]     = @NbLps,
	[MTypeId]   = @MTypeId,
	[FormatId]  = @FormatId, 
	[SerialNbr] = trim(@SerialNbr),
	[Ctry]      = trim(@Ctry)
	WHERE [Id]  = @Id;
	RETURN 0
END
