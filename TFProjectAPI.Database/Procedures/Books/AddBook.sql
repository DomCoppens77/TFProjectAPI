CREATE PROCEDURE [AppUser].[AddBook]
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
	DECLARE @ID AS INT;

	EXEC [dbo].[AddOject] @Price, @Curr, @ShopId, @Date, @OTypeId, @Signed, @SignedBy, @EAN, @EAN_EXT, @Comment1, @Comment2, @ID output;

	INSERT INTO [Books] ([Id], [Serie], [Title], [Writer1], [Writer2], [Language], [Edition], [Format], [Number], [Pages], [YEAR], [FirstPrint]) 
    OUTPUT [inserted].[Id]
	VALUES(@ID, 
	TRIM(@Serie),
	TRIM(@Title),     
	TRIM(@Writer1),   
	TRIM(@Writer2),   
	UPPER(TRIM(@Language)),
	TRIM(@Edition),  
	TRIM(@Format),
	@Number,    
	@Pages,     
	@YEAR,      
	@FirstPrint
	);
END

	 

	