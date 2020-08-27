CREATE PROCEDURE [AppUser].[UpdShop]
	@Id int,
	@Name            NVARCHAR(50),
	@Address1        NVARCHAR(255),
	@Address2        NVARCHAR(255),
	@ZIP             NVARCHAR(15),
	@City            NVARCHAR(30),
	@Country         NVARCHAR(30),
	@Phone           NVARCHAR(50),
	@Email           NVARCHAR(320),
	@WebSite         NVARCHAR(150),
	@LocalisationURL NVARCHAR(255),
	@Closed          bit
AS
BEGIN
	UPDATE [Shop] SET
	[Name]            = trim(@Name), 
	[Address1]        = trim(@Address1),
	[Address2]        = trim(@Address2),       
	[ZIP]             = trim(@ZIP),
	[City]            = trim(@City),           
	[Country]         = trim(@Country),        
	[Phone]           = trim(@Phone),
	[Email]           = trim(@Email),
	[WebSite]         = trim(@WebSite),
	[LocalisationURL] = trim(@LocalisationURL),
	[Closed]          = @Closed         
	WHERE [Id] = @Id;
	RETURN 0
END
