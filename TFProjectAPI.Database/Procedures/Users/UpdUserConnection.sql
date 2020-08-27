CREATE PROCEDURE [AppUser].[UpdUserConnection]
	@Email NVARCHAR(320)
AS
BEGIN
	UPDATE [Users] SET
	[ConnectionCount] = [ConnectionCount] + 1,
	[ConnectionLast] = GETDATE()
	WHERE [Email] = @Email;
	RETURN 0
END