CREATE TABLE [dbo].[Installments] (
    [InstallmentId] INT             IDENTITY (1, 1) NOT NULL,
    [Loan_LoanId]        INT             NOT NULL,
    [InstallmentValue]   DECIMAL (15, 5) NOT NULL,
    CONSTRAINT [FK_Installments_Loans] FOREIGN KEY ([Loan_LoanId]) REFERENCES [dbo].[Loans] ([LoanId])
);

