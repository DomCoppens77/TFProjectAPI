CREATE PROCEDURE [AppUser].[AddShop]
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
	Insert into [Shop]([Name], [Address1],	[Address2],	[ZIP], [City], [Country], [Phone], [Email], [WebSite], [LocalisationURL], [Closed]) 
    output inserted.Id
    values(trim(@Name), trim(@Address1), trim(@Address2), trim(@ZIP), trim(@City), trim(@Country), trim(@Phone), trim(@Email), trim(@WebSite), trim(@LocalisationURL), @Closed );
END
