CREATE TABLE [dbo].[Loans] (
    [LoanId]              INT             IDENTITY (1, 1) NOT NULL,
    [LoanDescription]     NVARCHAR (MAX)  NULL,
    [LoanValue]           DECIMAL (15, 5) NOT NULL,
    [Customer_CustomerId] INT             NULL,
    CONSTRAINT [PK_dbo.Loans] PRIMARY KEY CLUSTERED ([LoanId] ASC),
    CONSTRAINT [FK_dbo.Loans_dbo.Customers_Customer_CustomerId] FOREIGN KEY ([Customer_CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
);

