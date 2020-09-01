CREATE PROCEDURE [AppUser].[GetCodeMstrFirst]
	@code_fldname nvarchar(20)
AS
BEGIN
	SELECT TOP 1 [code_value] FROM [code_mstr] WHERE [code_fldname] = @code_fldname;
END
