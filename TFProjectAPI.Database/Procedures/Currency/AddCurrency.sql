CREATE PROCEDURE [AppUser].[AddCurr]
	@Curr nvarchar(3),
	@Desc nvarchar(100)
AS
BEGIN
	Insert into [Currency]([Curr],[Description]) 
    values(@Curr,trim(@Desc));
END
