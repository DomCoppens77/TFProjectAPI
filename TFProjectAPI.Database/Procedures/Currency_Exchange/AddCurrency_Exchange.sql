CREATE PROCEDURE [AppUser].[AddCurrency_Exchange]
	@CurrF nvarchar(3),
	@CurrT nvarchar(3),
	@DateF datetime2,
	@DateT datetime2,
	@Rate float
AS
BEGIN
	IF (@CurrF != @CurrT AND @DateF <= @DateF AND @Rate != 0)
	INSERT INTO [Currency_Exchange]([CurrFrom], [CurrTo],[DateFrom],[DateTo],[Rate]) 
	OUTPUT inserted.Id
    VALUES(UPPER(TRIM(@CurrF)), UPPER(TRIM(@CurrT)),@DateF,@DateT,@Rate);
END
