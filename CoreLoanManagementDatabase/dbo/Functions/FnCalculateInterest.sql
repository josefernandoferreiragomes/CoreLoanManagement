CREATE FUNCTION [dbo].[FnCalculateInterest]
(
	@LoanAmount decimal(15,5),
	@InterestRate decimal(15,5),
	@Time int
)
RETURNS DECIMAL(15,5)
AS
BEGIN
	DECLARE @Result DECIMAL(15,5)
	DECLARE @TimeDecimal DECIMAL(15,5)
	DECLARE @YearDecimal DECIMAL(15,5)
	DECLARE @TimeRatio DECIMAL(15,5)

	SET @TimeDecimal=CONVERT(DECIMAL(15,5),@Time)
	SET @YearDecimal=CONVERT(DECIMAL(15,5),360)
	SET @TimeRatio=@TimeDecimal/@YearDecimal

	SET @Result=@LoanAmount*@InterestRate*@TimeRatio

	RETURN @Result
END