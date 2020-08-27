CREATE TABLE [dbo].[Currency_Exchange]
(
	[Id] INT IDENTITY NOT NULL ,
	[DateFrom] DATETIME2 NOT NULL,
	[DateTo] DATETIME2 NOT NULL,
	[CurrFrom] NVARCHAR(3) NOT NULL,
	[CurrTo] NVARCHAR(3) default 'EUR' NOT NULL,
	[Rate] FLOAT DEFAULT 1, 
    CONSTRAINT [PK_Currency_Exchange] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_CurrFrom] FOREIGN KEY ([CurrFrom]) REFERENCES [Currency]([Curr]),
	CONSTRAINT [FK_CurrTo] FOREIGN KEY ([CurrTo]) REFERENCES [Currency]([Curr]),
)
