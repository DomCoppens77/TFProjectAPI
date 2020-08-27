CREATE PROCEDURE [AppUser].[DelCurrency_Exchange]
	@Id int
AS
BEGIN
	DELETE FROM [Currency_Exchange] Where [Id] = @Id;
END

