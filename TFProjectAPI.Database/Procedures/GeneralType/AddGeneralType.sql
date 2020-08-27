CREATE PROCEDURE [dbo].[AddGeneralType]
	@Name nvarchar(15)
AS
BEGIN
	Insert into [GeneralType]([Name]) 
    output inserted.Id
    values(trim(@Name));
END
