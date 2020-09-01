CREATE PROCEDURE [AppUser].[ListBand]
AS
BEGIN
	SELECT DISTINCT([Band]) from [AppUser].[V_Music]
END
