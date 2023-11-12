using Microsoft.Extensions.Configuration;

namespace CoreLoanManagement.WebSite.Factories
{
    public class ConcreteAPIClientFactoryGeneric<T> : APIClientFactoryGeneric<T>
    {
        private IConfigurationRoot _configuration;
        private HttpClient _httpclient;
        public ConcreteAPIClientFactoryGeneric()
        {
            _httpclient = new HttpClient();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

        }

        public T data;
        public override T GetClient()
        {

            switch (typeof(T).Name)
            {
                case "Management":
                    _httpclient.BaseAddress = new Uri((string)_configuration.GetValue(typeof(string), "LoanApiClient"));
                    //_httpclient.BaseAddress = new Uri(@"http://localhost:51852/Api/LoanManager/");
                    data = (T)Activator.CreateInstance(typeof(T), (string)_configuration.GetValue(typeof(string), "LoanApiClient"), _httpclient);
                    break;
                //case "LoanManagerClient":
                //    _httpclient.BaseAddress = new Uri((string)_configuration.GetValue(typeof(string),"CustomerApiClient"));
                //    //_httpclient.BaseAddress = new Uri(@"http://localhost:51852/Api/LoanManager/");
                //    data = (T)Activator.CreateInstance(typeof(T), _httpclient);
                //    break;
                //case "LoanInstallmentClient":
                //    _httpclient.BaseAddress = new Uri((string)_configuration.GetValue(typeof(string),"LoanApiClient"));
                //    //_httpclient.BaseAddress = new Uri(@"http://localhost:51852/Api/LoanInstallment/");
                //    data = (T)Activator.CreateInstance(typeof(T), _httpclient);
                //    break;
                //case "CustomerItemClient":
                //    _httpclient.BaseAddress = new Uri((string)_configuration.GetValue(typeof(string),"CustomerItemClient"));
                //    //_httpclient.BaseAddress = new Uri(@"http://localhost:51852/Api/CustomerItem/");
                //    data = (T)Activator.CreateInstance(typeof(T), _httpclient);
                //    break;

            }
            return data;
        }

    }
}