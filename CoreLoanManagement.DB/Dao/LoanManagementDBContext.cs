using LoanManagement.DB.Data;
using Microsoft.EntityFrameworkCore;

namespace LoanManagement.DB.Dao
{
    public class LoanManagementDBContext: DbContext
    {

        private readonly string _connectionString;
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public DbSet<Installment> Installments { get; set; }

        public LoanManagementDBContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        //https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
        //PM > Install-Package Microsoft.EntityFrameworkCore.SqlServer
        public LoanManagementDBContext(DbContextOptions<LoanManagementDBContext> options)
        : base(options)
        {
        }
        //public LoanManagementDBContext() : base( new DbContextOptionsBuilder(  new DbContextOptions"name=LoanManagement.DB.Dao.LoanManagementDBContext" ) ) 
        //{

        //    //Database.SetInitializer<LoanManagementDBContext>(new CreateDatabaseIfNotExists<LoanManagementDBContext>());

        //    //for reset purposes
        //    //Database.SetInitializer<LoanManagementDBContext>(new DropCreateDatabaseAlways<LoanManagementDBContext>());

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().Property(loan => loan.LoanValue).HasPrecision( 15,5);
            
            modelBuilder.Entity<Installment>().Property(installment => installment.InstallmentValue).HasPrecision(15, 5);
          
        }
    }
}
