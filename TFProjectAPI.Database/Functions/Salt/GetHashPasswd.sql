CREATE FUNCTION [dbo].[GetHashPasswd]
(
	@Passwd NVARCHAR(20)
)
RETURNS BINARY(64)
AS
BEGIN
	return HASHBYTES('SHA2_512', [dbo].[GetPreSalt]() + @Passwd + [dbo].[GetPostSalt]());
END
