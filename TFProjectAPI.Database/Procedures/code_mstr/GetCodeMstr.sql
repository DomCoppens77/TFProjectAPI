CREATE PROCEDURE [AppUser].[GetCodeMstr]
	@code_fldname nvarchar(20)
AS
BEGIN
	SELECT [code_value], [code_desc] FROM [code_mstr] WHERE [code_fldname] = @code_fldname;
END
