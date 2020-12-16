CREATE PROCEDURE [AppUser].[UpdCurrency_Exchange]
	@Id integer,
	@CurrF nvarchar(3),
	@CurrT nvarchar(3),
	@DateF datetime2,
	@DateT datetime2,
	@Rate float
AS
BEGIN
	IF (@CurrF != @CurrT AND @DateF <= @DateF AND @Rate != 0)
	UPDATE [Currency_Exchange] SET
	[CurrFrom] = UPPER(TRIM(@CurrF)),
	[CurrTo]   = UPPER(TRIM(@CurrT)),
	[DateFrom] = @DateF,
	[DateTo] = @DateT,
	[Rate] = @Rate
	WHERE [Id] = @Id;
END
