CREATE TABLE [dbo].[Books]
(
	[Id]       INTEGER NOT NULL, 
	[Serie]    NVARCHAR(50) NOT NULL,
	[Title]    NVARCHAR(50) NOT NULL,
	[Writer1]  NVARCHAR(30) DEFAULT '',
	[Writer2]  NVARCHAR(30) DEFAULT '',
	[Language] NVARCHAR(2) DEFAULT 'FR',
	[Edition]  NVARCHAR(20) DEFAULT '',
	[Format]   NVARCHAR(20) DEFAULT '',
	[Number]   INTEGER,
	[Pages]    INTEGER NOT NULL default 1,
	[YEAR]     INTEGER NOT NULL,
	[FirstPrint] bit not null default 0,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Books_Id] FOREIGN KEY ([Id]) REFERENCES [Object]([Id])
)
