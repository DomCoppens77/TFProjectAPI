CREATE PROCEDURE [AppUser].[SearchODescCnt]
	@search NVARCHAR(50)
AS
BEGIN
	
SELECT count(*) FROM [AppUser].[V_Object] as O WHERE UPPER([O].[OBJTEXT]) LIKE ('%' + UPPER(@search) + '%') 
	
END
