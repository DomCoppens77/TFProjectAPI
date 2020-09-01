CREATE PROCEDURE [AppUser].[ListFldName]
AS
BEGIN
	SELECT DISTINCT([code_fldname]) from [AppUser].[V_Code_Mstr]
END
