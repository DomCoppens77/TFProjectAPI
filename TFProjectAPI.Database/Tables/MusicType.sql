﻿CREATE TABLE [dbo].[MusicType]
(
	[Id] INT IDENTITY NOT NULL, 
	[Name] NVARCHAR(10),
    CONSTRAINT [PK_MusicType] PRIMARY KEY ([Id]),
)
GO