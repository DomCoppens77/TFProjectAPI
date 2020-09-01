CREATE VIEW [AppUser].[V_Music_Full]
	AS SELECT 
	  [Object].[Id]
	 ,[Object].[Price]
	 ,[Object].[Curr]
	 ,[Object].[ShopId]
	 ,[Shop].[Name] as ShopName
	 ,[Object].[Date]
     ,[Object].[Signed]
	 ,[Object].[SignedBy]
	 ,[Object].[EAN]
	 ,[Object].[EAN_EXT]
	 ,[Object].[Comment1]
	 ,[Object].[Comment2]
	 ,[Object].[Onwed]
	 ,[Music].[Band]
	 ,[Music].[Title]
	 ,[Music].[YEAR]
	 ,[Music].[TRACKS]
	 ,[Music].[NbCDs]
	 ,[Music].[NbDvds]
	 ,[Music].[NbLps]
	 ,[Music].[MTypeId]
	 ,[MusicType].[Name] as MusicTypeName
	 ,[Music].[FormatId]
	 ,[MusicFormat].[Name] as MusicFormatName
	 ,[Music].[SerialNbr]
	 ,[Music].[Ctry]
	FROM [Object] 
	INNER JOIN [Music]       on [Object].[Id] = [Music].[Id] 
	INNER JOIN [MusicFormat] on [Music].[FormatId] = [MusicFormat].[Id]
	INNER JOIN [MusicType]   on [Music].[MTypeId]  = [MusicType].[Id]
	INNER JOIN [Shop]        on [Object].[ShopId] = [Shop].[Id]
	WHERE [Object].[TypeId] = 1


