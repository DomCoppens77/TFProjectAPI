CREATE PROCEDURE [AppUser].[AddCodeMstr]
	@code_fldname nvarchar(20),
	@code_value nvarchar(40),
	@code_desc nvarchar(100)
AS
BEGIN
	Insert into [code_mstr]([code_fldname],[code_value],[code_desc]) 
    values(@code_fldname,@code_value,@code_desc);
END

