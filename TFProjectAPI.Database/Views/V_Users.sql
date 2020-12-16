CREATE VIEW [AppUser].[V_Users]
	AS SELECT [Id]
    ,[FirstName]
    ,[LastName]
    ,[Email]
    ,[Passwd]
    ,[Active]
    ,[Status]
    ,[ConnectionCount]
    ,[ConnectionLast]
    ,[Avatar]
	 FROM [Users] 

     --Used in RENEW TOKEN so should take all user even ADMIN
     -- remove Password ?? to becheck if not conflictuel