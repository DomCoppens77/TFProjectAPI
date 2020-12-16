CREATE PROCEDURE [AppUser].[SearchOEANCnt]
	@EAN NVARCHAR(50)
AS
BEGIN
	
SELECT count(*) FROM [AppUser].[V_Object] as O WHERE UPPER([O].[EAN_FULL]) LIKE ('%' + UPPER(@EAN) + '%') 
	
END