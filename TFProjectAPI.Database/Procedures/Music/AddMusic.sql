CREATE PROCEDURE [AppUser].[AddMusic]

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
	DECLARE @ID AS INT;

	exec [dbo].[AddOject] @Price, @Curr, @ShopId, @Date, @OTypeId, @Signed, @SignedBy, @EAN, @EAN_EXT, @Comment1, @Comment2, @ID output;

	Insert into [Music] ([Id], [Band], [Title], [YEAR], [TRACKS], [NbCDs], [NbDvds], [NbLps], [MTypeId], [FormatId], [SerialNbr],[Ctry]) 
    output inserted.Id
	values(@ID, trim(@Band), trim(@Title), @YEAR, trim(@TRACKS), @NbCDs, @NbDvds, @NbLps, @MTypeId, @FormatId, trim(@SerialNbr),trim(@Ctry));

END
