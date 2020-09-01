CREATE PROCEDURE [AppUser].[FindBand]
	@Band NVARCHAR(50)
AS
BEGIN
	SELECT * from [AppUser].[V_Music_Full] where [Band] = @Band
END
