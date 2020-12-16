CREATE PROCEDURE [AppUser].[SearchODesc]
	@page int,
	@jump int, 
	@search NVARCHAR(50)
AS
BEGIN

	DECLARE @PageNumber AS INT = 1
	DECLARE @RowsOfPage AS INT = 50
	SET @PageNumber=@page
	SET @RowsOfPage=@jump

	IF @PageNumber < 1 SET @PageNumber = 1
	IF @RowsOfPage < 1 SET @RowsOfPage = 50
		
SELECT [O].[Id]
, [O].[PRICE_EUR]
, [O].[TypeId]
, [O].[GenTypeName]
, [O].[EAN] 
, [O].[EAN_EXT]
 ,[O].[EAN_FULL]
, [O].[ShopId]
, [O].[ShopName]
, [O].[OBJTEXT]
FROM [AppUser].[V_Object] as O
WHERE UPPER([O].[OBJTEXT]) LIKE ('%' + UPPER(@search) + '%') 
	ORDER BY [O].[TypeId] 
	OFFSET (@PageNumber-1)*@RowsOfPage ROWS
	FETCH NEXT @RowsOfPage ROWS ONLY;
	
END