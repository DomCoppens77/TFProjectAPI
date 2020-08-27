CREATE PROCEDURE [AppUser].[UpdCodeMstr]
	@code_fldname nvarchar(20),
	@code_value nvarchar(40),
	@code_desc nvarchar(100)
AS
BEGIN
	UPDATE [code_mstr] SET
	[code_desc] = @code_desc
	WHERE [code_fldname] = @code_fldname AND [code_value] = @code_value;
END
