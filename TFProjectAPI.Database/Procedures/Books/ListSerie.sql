CREATE PROCEDURE [dbo].[ListSeries]
AS
BEGIN
	SELECT DISTINCT([Serie]) from [AppUser].[V_Books]
END
