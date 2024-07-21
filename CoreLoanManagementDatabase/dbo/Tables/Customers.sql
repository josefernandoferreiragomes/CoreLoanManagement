CREATE TABLE [dbo].[Customers] (
    [CustomerId]   INT           IDENTITY (1, 1) NOT NULL,
    [CustomerName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

