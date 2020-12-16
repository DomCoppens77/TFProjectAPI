CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY NOT NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL,
    [Email] NVARCHAR(320) NOT NULL UNIQUE,
    [Passwd] BINARY(64) NOT NULL,
    [SecretAnswer] BINARY(64) NOT NULL,
    [Active] BIT NOT NULL DEFAULT 1, 
    [Status] INTEGER DEFAULT 1 NOT NULL,
    [ConnectionCount] INTEGER DEFAULT 0 NOT NULL,
    [ConnectionLast] DATETIME2 NOT NULL DEFAULT GETDATE(),
    [Avatar] NVARCHAR(MAX) NOT NULL DEFAULT '', 
    CONSTRAINT [PK_usr_mstr] PRIMARY KEY ([Id]) ,
    CONSTRAINT [UK_usr_email] unique ([Email]),
)
GO

CREATE TRIGGER [dbo].[Trigger_UserDel]
    ON [dbo].[Users] 
    INSTEAD OF DELETE
    AS
    BEGIN
        SET NoCount ON
        update [Users] set [Active] = 0 where [Id] in (select [Id] from deleted where [Active] = 1)
    END