CREATE PROCEDURE [AppUser].[UpdShop]
	@Id int,
	@Name            NVARCHAR(50),
	@Address1        NVARCHAR(255),
	@Address2        NVARCHAR(255),
	@ZIP             NVARCHAR(15),
	@City            NVARCHAR(30),
	@Country         NVARCHAR(2),
	@Phone           NVARCHAR(50),
	@Email           NVARCHAR(320),
	@WebSite         NVARCHAR(150),
	@LocalisationURL NVARCHAR(255),
	@Closed          bit
AS
BEGIN
	UPDATE [Shop] SET
	[Name]            = TRIM(@Name), 
	[Address1]        = TRIM(@Address1),
	[Address2]        = TRIM(@Address2),       
	[ZIP]             = TRIM(@ZIP),
	[City]            = TRIM(@City),           
	[Country]         = UPPER(TRIM(@Country)),        
	[Phone]           = TRIM(@Phone),
	[Email]           = TRIM(@Email),
	[WebSite]         = TRIM(@WebSite),
	[LocalisationURL] = TRIM(@LocalisationURL),
	[Closed]          = @Closed         
	WHERE [Id] = @Id;
	RETURN 0
END
