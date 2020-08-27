CREATE TABLE [dbo].[MusicFormat]
(
	[Id] INT IDENTITY NOT NULL, 
	[Name] NVARCHAR(20),
    CONSTRAINT [PK_MusicFormat] PRIMARY KEY ([Id]), 
)
GO