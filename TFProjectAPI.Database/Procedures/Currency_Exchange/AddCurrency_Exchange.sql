CREATE PROCEDURE [AppUser].[AddCurrency_Exchange]
	@CurrF nvarchar(3),
	@CurrT nvarchar(3),
	@DateF datetime2,
	@DateT datetime2,
	@Rate float
AS
BEGIN
	Insert into [Currency_Exchange]([CurrFrom], [CurrTo],[DateFrom],[DateTo],[Rate]) 
	output inserted.Id
    values(trim(@CurrF), trim(@CurrT),@DateF,@DateT,@Rate);
END
