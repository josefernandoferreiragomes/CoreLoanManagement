using LoanManagement.DB.Dao;
using LoanManagement.DB.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;


namespace LoanManagement.DB.DaoSqlExecuters
{
    public class LoanManagementDBExecuter
    {
        //private IConfigurationRoot _configuration;
        //private const string ConfigKeyName= "";
        DbContextOptions<LoanManagementDBContext> _options;
        private String SqlconString;

        public LoanManagementDBExecuter()
        {

        }

        public LoanManagementDBExecuter(DbContextOptions<LoanManagementDBContext> options)
        {
            _options=options;
            //_configuration = new Configuration();
            //SqlconString = _configuration.GetConnectionString(ConfigKeyName);
        }
        public LoanManagementDBExecuter(DbContextOptions<LoanManagementDBContext> options, string connectionString)
        {
            _options = options;
            SqlconString = connectionString;
        }
        SqlConnection sqlCon = null;

        //https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings
        //String SqlconString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoanManagementDB;Encrypt=False;Integrated Security=true";
        public CustomerLoanInstallmentDBOut CustomerInstallmentGetPage(CustomerLoaInstallmentDBIn objIn)
        {
            CustomerLoanInstallmentDBOut ObjDbOut =new CustomerLoanInstallmentDBOut();
            ObjDbOut.ListOfItems = new List<CustomerLoanInstallmentDBOutItem>();

            
            using (sqlCon = new SqlConnection(SqlconString))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("SpGetPageOfCustomerInstalments", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@CustomerId", SqlDbType.NVarChar).Value = objIn.CustomerId;
                    sql_cmnd.Parameters.AddWithValue("@PageSize", SqlDbType.NVarChar).Value = objIn.PageSize;
                    sql_cmnd.Parameters.AddWithValue("@LastPageLastInstallmentId", SqlDbType.Int).Value = objIn.LastPageLastInstallmentId;
                    SqlDataReader reader = sql_cmnd.ExecuteReader();

                    while (reader.Read())
                    {
                        CustomerLoanInstallmentDBOutItem item = new CustomerLoanInstallmentDBOutItem();
                        item.InstallmentId = (int)reader["CustomerId"];
                        item.CustomerName = (string)reader["CustomerName"];
                        item.LoanDescription = (string)reader["LoanDescription"];
                        item.InstallmentValue = (decimal)reader["InstallmentValue"];
                        item.InstallmentId = (int)reader["InstallmentId"];
                        ObjDbOut.ListOfItems.Add(item);
                    }

                }
                catch (Exception ex)
                {
                    //TODO Error handling
                    throw ex;
                }
                finally
                {
                    sqlCon.Close();
                }
            }
            return ObjDbOut;
        }
    }
}
