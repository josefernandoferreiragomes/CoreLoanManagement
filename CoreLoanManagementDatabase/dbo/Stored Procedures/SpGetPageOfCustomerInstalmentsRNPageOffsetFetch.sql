CREATE PROCEDURE [dbo].[SpGetPageOfCustomerInstalmentsRNPageOffsetFetch]
	@CustomerId int=0,
	@PageSize int=2,
	@PageNumber int=1
AS
BEGIN
		DECLARE @OffsetRows int
		DECLARE @FetchRows int
		SET @OffsetRows = ((@PageNumber-1)*(@PageSize))
		PRINT @OffsetRows
		SET @FetchRows = @PageSize
		;with cte as(
		SELECT cust.CustomerId, cust.CustomerName, ln.LoanDescription, inst.InstallmentValue, inst.InstallmentId, ROW_NUMBER() OVER (ORDER BY inst.InstallmentId) AS RowId
		FROM Installments inst INNER JOIN Loans ln ON inst.Loan_LoanId = ln.LoanId INNER JOIN Customers cust ON ln.Customer_CustomerId=cust.CustomerId
		WHERE cust.CustomerId=@CustomerId OR @CustomerId =0
		)	
		SELECT * FROM cte 
		ORDER BY RowId OFFSET @OffsetRows  ROWS FETCH NEXT @FetchRows ROWS ONLY
END
RETURN 0
