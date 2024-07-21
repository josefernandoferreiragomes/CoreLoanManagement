


CREATE PROCEDURE [dbo].[SpCalculateLoanInterest]
	@LoanId int,
	@InterestRate decimal(15,5),
	@TimeDays int
	
AS
	DECLARE @LoanInterest decimal(15,5)
	DECLARE @LoanValue decimal(15,5)
	
	SET  @LoanValue=(
	SELECT LoanValue FROM Loans
	WHERE LoanId=@LoanId)
	PRINT @LoanValue
	PRINT @InterestRate
	PRINT @TimeDays

	SET @LoanInterest = dbo.FnCalculateInterest(@LoanValue, @InterestRate, @TimeDays)

	PRINT @LoanInterest

	INSERT INTO dbo.Installments
	(Loan_LoanId, InstallmentValue)
	SELECT @LoanId, @LoanInterest
	

RETURN 0
