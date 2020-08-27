CREATE TABLE [dbo].[Music]
(
	[Id] INT NOT NULL, 
	[Band] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[YEAR] INTEGER,
	[TRACKS] NVARCHAR(100),
	[NbCDs] INTEGER default 0,
	[NbDvds] INTEGER default 0,
	[NbLps] INTEGER default 0,
	[MTypeId] INTEGER NOT NULL,
	[FormatId] INTEGER NOT NULL,
	[SerialNbr] NVARCHAR(50), 
	[Ctry] NVARCHAR(2)

    CONSTRAINT [PK_Music] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Music_Id] FOREIGN KEY ([Id]) REFERENCES [Object]([Id]),
	CONSTRAINT [FK_Music_TypeId] FOREIGN KEY ([MTypeId]) REFERENCES [MusicType]([Id]),
	CONSTRAINT [FK_Music_FormatId] FOREIGN KEY ([FormatId]) REFERENCES [MusicFormat]([Id]),
)
