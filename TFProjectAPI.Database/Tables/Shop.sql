CREATE TABLE [dbo].[Shop]
(
	[Id] INT IDENTITY NOT NULL, 
	[Name] NVARCHAR(50) NOT NULL,
	[Address1] NVARCHAR(255),
	[Address2] NVARCHAR(255),
	[ZIP] NVARCHAR(15),
	[City] NVARCHAR(30),
	[Country] NVARCHAR(2) NOT NULL,
	[Phone] NVARCHAR(50),
	[Email] NVARCHAR(320),
	[WebSite] NVARCHAR(150),
	[LocalisationURL] NVARCHAR(255),
	[Closed] BIT default 1
    CONSTRAINT [PK_Shop] PRIMARY KEY ([Id]) NOT NULL,
)

