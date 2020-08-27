CREATE PROCEDURE [dbo].[UpdCurrency_Exchange]
	@Id integer,
	@CurrF nvarchar(3),
	@CurrT nvarchar(3),
	@DateF datetime2,
	@DateT datetime2,
	@Rate float
AS
BEGIN
	UPDATE [Currency_Exchange] SET
	[CurrFrom] = trim(@CurrF),
	[CurrTo]   = trim(@CurrT),
	[DateFrom] = @DateF,
	[DateTo] = @DateT,
	[Rate] = @Rate
	WHERE [Id] = @Id;
END
