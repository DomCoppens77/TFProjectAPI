﻿CREATE PROCEDURE [AppUser].[Check_CX_DateT]
	@CurrF nvarchar(3),
	@CurrT nvarchar(3),
	@Date2Chk datetime2
AS
BEGIN
	SELECT count(*) from [Currency_Exchange] WHERE
	[Currency_Exchange].[CurrFrom] = UPPER(TRIM(@CurrF))
	AND [Currency_Exchange].[CurrTo] = UPPER(TRIM(@CurrT))
	AND [Currency_Exchange].[DateTo] = @Date2Chk;
END
