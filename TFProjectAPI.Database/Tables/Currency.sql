CREATE TABLE [dbo].[Currency]
(
	[Curr] NVARCHAR(3) NOT NULL,
	[Description] NVARCHAR(100), 
    CONSTRAINT [PK_Currency] PRIMARY KEY ([Curr])
)
