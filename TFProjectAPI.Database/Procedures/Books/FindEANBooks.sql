CREATE PROCEDURE [AppUser].[FindEANBooks]
	@EAN NVARCHAR(15)
AS
BEGIN
	SELECT* from [AppUser].[V_Book_Full] where [EAN] = @EAN
END
