CREATE VIEW [AppUser].[V_Object]
	AS SELECT  [O].[Id]
	 ,[O].[Price]
	 ,[O].[Curr]
	 ,[O].[ShopId]
	 ,[S].[Name] as [ShopName]
	 ,[O].[Date]
	 ,[O].[TypeId]
	 ,[G].[Name] as [GenTypeName]
     ,[O].[Signed]
	 ,[O].[SignedBy]
	 ,[O].[EAN]
	 ,[O].[EAN_EXT]
	 ,CONCAT([O].[EAN],[O].[EAN_EXT]) as [EAN_FULL]
	 ,[O].[Comment1]
	 ,[O].[Comment2]
	 ,[O].[Onwed]
	 ,CONVERT(money, 	
			CASE [O].[Curr]										
			WHEN 'EUR' then [O].[Price]
			ELSE ROUND([O].[Price] / (SELECT [ce].[Rate] from [Currency_Exchange] as ce 
											WHERE [ce].[CurrFrom] = [O].[Curr] 
											AND [ce].[CurrTo] = 'EUR'
											AND	[O].[Date] BETWEEN [ce].[DateFrom] AND [ce].[DateTo]) ,2)
		END) as [PRICE_EUR]
	 , CASE [O].[TypeId]
			WHEN '1' then (SELECT CONCAT( [M].[Band], ' ' , [M].[Title] ) from [AppUser].[V_Music] as M WHERE [M].[Id] = [O].[Id])
			WHEN '2' then (SELECT CONCAT( [B].[Serie], ' ' , [B].[Title], ' ' , [B].[Number]) from [AppUser].[V_Books] as B WHERE [B].[Id] = [O].[Id])
			ELSE (' ')
			END as [OBJTEXT]
	FROM [Object] as O
	INNER JOIN [GeneralType] as G on [G].[Id] = [O].[TypeId] 
	INNER JOIN [dbo].[Shop]  as S on [S].[Id] = [O].[ShopId]