CREATE PROCEDURE [dbo].[SpGetPageOfCustomerInstalmentsRNPage]
	@CustomerId int=0,
	@PageSize int=2,
	@PageNumber int=1
AS
BEGIN

		;with cte as(
		SELECT cust.CustomerId, cust.CustomerName, ln.LoanDescription, inst.InstallmentValue, inst.InstallmentId, ROW_NUMBER() OVER (ORDER BY inst.InstallmentId) AS RowId
		FROM Installments inst INNER JOIN Loans ln ON inst.Loan_LoanId = ln.LoanId INNER JOIN Customers cust ON ln.Customer_CustomerId=cust.CustomerId
		WHERE cust.CustomerId=@CustomerId OR @CustomerId =0
		)	
		SELECT * FROM cte WHERE RowId BETWEEN (@PageNumber-1)*@PageSize+1 AND @PageNumber*@PageSize
END
RETURN 0
