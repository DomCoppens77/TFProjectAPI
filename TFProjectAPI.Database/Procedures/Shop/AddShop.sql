CREATE PROCEDURE [AppUser].[AddShop]
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
	Insert into [Shop]([Name], [Address1],	[Address2],	[ZIP], [City], [Country], [Phone], [Email], [WebSite], [LocalisationURL], [Closed]) 
    output inserted.Id
    values(TRIM(@Name), TRIM(@Address1), TRIM(@Address2), TRIM(@ZIP), TRIM(@City), UPPER(TRIM(@Country)), TRIM(@Phone), TRIM(@Email), TRIM(@WebSite), TRIM(@LocalisationURL), @Closed);
END
