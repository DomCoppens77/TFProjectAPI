﻿CREATE PROCEDURE [AppUser].[CheckMusicFormat]
	@Id int 
AS
BEGIN
	DECLARE @Cnt INT;
	SET @Cnt = [dbo].[SF_CountMusicFormat](@Id);
	SELECT @Cnt;
END