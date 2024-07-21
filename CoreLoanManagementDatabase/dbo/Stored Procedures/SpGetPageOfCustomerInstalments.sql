-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SpGetPageOfCustomerInstalments
	@CustomerId int=0
	, @PageSize int=2
	,@LastPageLastInstallmentId int=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT cust.CustomerId, cust.CustomerName, ln.LoanDescription, inst.InstallmentValue, inst.InstallmentId
	FROM Installments inst INNER JOIN Loans ln ON inst.Loan_LoanId = ln.LoanId INNER JOIN Customers cust ON ln.Customer_CustomerId=cust.CustomerId
	WHERE cust.CustomerId=@CustomerId OR @CustomerId =0
	AND inst.InstallmentId > @LastPageLastInstallmentId
	ORDER BY inst.InstallmentId OFFSET 0 ROWS FETCH NEXT @PageSize ROWS ONLY
END
