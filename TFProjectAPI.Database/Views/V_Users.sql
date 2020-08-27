CREATE VIEW [AppUser].[V_Users]
	AS SELECT 
	[Id],
    [FirstName],
    [LastName],
    [Email],
    [Passwd],
    [Active],
    [Status],
    [ConnectionCount],
    [ConnectionLast]
	 FROM [Users]
