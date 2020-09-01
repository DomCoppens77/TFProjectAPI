﻿CREATE PROCEDURE [AppUser].[PaginateMusic]
	@page int,
	@jump int
AS
BEGIN
	DECLARE @PageNumber AS INT = 1
	DECLARE @RowsOfPage AS INT = 50
	SET @PageNumber=@page
	SET @RowsOfPage=@jump

	SELECT * FROM [AppUser].[V_Music_Full]
	ORDER BY [Band] ASC, [YEAR] ASC, [Title] ASC
	OFFSET (@PageNumber-1)*@RowsOfPage ROWS
	FETCH NEXT @RowsOfPage ROWS ONLY	
END
