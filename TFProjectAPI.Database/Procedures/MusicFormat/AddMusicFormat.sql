CREATE PROCEDURE [AppUser].[AddMusicFormat]
	@Name NVARCHAR(20)
AS
BEGIN
	Insert into [MusicFormat]([Name]) 
    output inserted.Id
    values(trim(@Name));
END
