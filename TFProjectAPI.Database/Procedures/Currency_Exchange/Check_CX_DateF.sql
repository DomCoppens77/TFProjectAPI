CREATE PROCEDURE [AppUser].[Check_CX_DateF]
	@CurrF nvarchar(3),
	@CurrT nvarchar(3),
	@Date2Chk datetime2
AS
BEGIN
	SELECT count(*) from [Currency_Exchange] WHERE
	[Currency_Exchange].[CurrFrom] = UPPER(TRIM(@CurrF))
	AND [Currency_Exchange].[CurrTo] = UPPER(TRIM(@CurrT))
	AND [Currency_Exchange].[DateFrom] = @Date2Chk;
END
