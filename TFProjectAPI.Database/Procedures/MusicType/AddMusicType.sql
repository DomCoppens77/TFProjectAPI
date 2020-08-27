CREATE PROCEDURE [AppUser].[AddMusicType]
	@Name NVARCHAR(20)
AS
BEGIN
	Insert into [MusicType]([Name]) 
    output inserted.Id
    values(trim(@Name));
END
