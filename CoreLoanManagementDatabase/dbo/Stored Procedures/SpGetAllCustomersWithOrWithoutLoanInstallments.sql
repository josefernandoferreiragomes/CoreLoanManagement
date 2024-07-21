CREATE PROCEDURE [dbo].[SpGetAllCustomersWithOrWithoutLoanInstallments]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT cust.CustomerId, cust.CustomerName, ln.LoanDescription, inst.InstallmentValue, inst.InstallmentId
	FROM Installments inst RIGHT JOIN Loans ln ON inst.Loan_LoanId = ln.LoanId RIGHT JOIN Customers cust ON ln.Customer_CustomerId=cust.CustomerId
	
	ORDER BY cust.CustomerName OFFSET 0 ROWS FETCH NEXT 5000 ROWS ONLY
END
RETURN 0
