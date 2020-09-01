CREATE PROCEDURE [AppUser].[FindEAN]
	@EAN NVARCHAR(15)
AS
BEGIN
	SELECT* from [AppUser].[V_Music_Full] where [EAN] = @EAN
END
