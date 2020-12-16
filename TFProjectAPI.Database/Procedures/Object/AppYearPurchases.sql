CREATE PROCEDURE [AppUser].[AppYearPurchases]
AS
BEGIN
SELECT
	 Sum([O].[PRICE_EUR]) as [sumprice] ,[O].[TypeId], [GenTypeName] ,datepart(yyyy, [O].[Date]) as [year]
		FROM [AppUser].[V_Object] as O
			GROUP BY datepart(yyyy, [O].[Date]), [O].[TypeId], [O].GenTypeName
			ORDER by datepart(yyyy, [O].[Date]) ASC;
END
