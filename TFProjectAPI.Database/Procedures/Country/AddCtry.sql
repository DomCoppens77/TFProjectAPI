CREATE PROCEDURE [AppUser].[AddCtry]
	@ISO NVARCHAR(2),
	@Ctry NVARCHAR(20),
	@IsEU BIT
AS
BEGIN
	Insert into [Country]([ISO],[Ctry],IsEU) 
    values(@ISO,trim(@Ctry),@IsEU);
END
