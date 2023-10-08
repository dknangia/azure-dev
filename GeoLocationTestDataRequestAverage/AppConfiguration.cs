using Microsoft.Extensions.Configuration;

namespace GeoLocationTestDataRequestAverage
{

    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        public string? GetValue(string? key)
        {
            return this._configuration[key];
        }
    }

    public interface IAppConfiguration
    {
        string? GetValue(string? key);
    }
}

