﻿CREATE ROLE [AppUser]
GO

GRANT SELECT, EXECUTE ON SCHEMA::AppUser To AppUser
GO

ALTER ROLE [AppUser]
ADD MEMBER [GestUser]
GO
