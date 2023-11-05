using LoanManagement.DB.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;

namespace LoanManagement.DB.Dao
{
    public class LoanManagementDBInitializer : DbSetInitializer //: CreateDatabaseIfNotExists<LoanManagementDBContext>
    {
        public LoanManagementDBInitializer(IDbSetFinder setFinder, IDbSetSource setSource) : base(setFinder, setSource)
        {
        }

        //if implements DropCreateDatabaseAlways
        //public override void InitializeDatabase(LoanManagementDBContext context)
        //{
        //    context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
        //    , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

        //    base.InitializeDatabase(context);
        //}
        protected void Seed(LoanManagementDBContext context)
        {
            
            List<Customer> customers = new List<Customer>();
            Customer customerA = new Customer() { CustomerName = "Jack Ma" };
            Customer customerB = new Customer() { CustomerName = "Jack Dorsey" };

            customers.Add(customerA);
            customers.Add(customerB);
            customers.Add(new Customer() { CustomerName = "John Doe" });            
            customers.Add(new Customer() { CustomerName = "Satya Nadella" });
            customers.Add(new Customer() { CustomerName = "Elon Musk" });
            customers.Add(new Customer() { CustomerName = "Elizabeth Holmes" });
            customers.Add(new Customer() { CustomerName = "Sundar Pichai" });

            context.Customers.AddRange(customers);

            List<Loan> loans = new List<Loan>();
            Loan loanA = new Loan() { Customer = customerA, LoanDescription = "Mortgage loan", LoanValue = 100000 };
            Loan loanB = new Loan() { Customer = customerB, LoanDescription = "Leasing loan", LoanValue = 50000 };
            loans.Add(loanA);
            loans.Add(loanB);

            context.Loans.AddRange(loans);

            List<Installment> installments = new List<Installment>();
            installments.Add(new Installment() { Loan = loanA, InstallmentValue = loanA.LoanValue / 36 });
            installments.Add(new Installment() { Loan = loanB, InstallmentValue = loanB.LoanValue / 36 });

            context.Installments.AddRange(installments);

            context.SaveChanges();
            //base.Seed(context);

        }

    }
}
