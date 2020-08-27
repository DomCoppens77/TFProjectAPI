CREATE PROCEDURE [AppUser].[DelCodeMstr]
	@code_fldname nvarchar(20),
	@code_value nvarchar(40)
AS
BEGIN
	DELETE FROM [code_mstr] WHERE [code_fldname] = @code_fldname AND [code_value] = @code_value;
END
