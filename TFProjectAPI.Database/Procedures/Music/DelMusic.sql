﻿CREATE PROCEDURE [AppUser].[DelMusic]
	@Id int
AS
BEGIN
	DELETE FROM [Music] Where [Id] = @Id; /* On DELETE CASCADE HAS BEEN SET UP in MUSIC FK */
END
