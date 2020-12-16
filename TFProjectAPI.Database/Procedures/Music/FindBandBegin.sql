CREATE PROCEDURE [AppUser].[FindBandBegin]
	@BeginLetter CHAR
AS
BEGIN
	SELECT [MF].[Id],[MF].[Band],[MF].[Title],
	[MF].[SerialNbr],[MF].[EAN],[MF].[MusicTypeName],[MF].[MusicFormatName]
	FROM [AppUser].[V_Music_Full] as [MF]
	WHERE UPPER([MF].[Band]) LIKE (UPPER(@BeginLetter)  + '%') 
	ORDER BY [Band] ASC, [YEAR] ASC, [Title] ASC
END