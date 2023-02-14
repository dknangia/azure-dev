using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SpinV2FixShortTermSolution
{

    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfiguration _configuration;

        public AppConfiguration()
        {



            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            var appConfig = _configuration.GetSection(nameof(AppConfig)).Get<AppConfig>();



        }

        public string GetValue(string settingName)
        {
            return _configuration[settingName] ?? string.Empty;
        }

    }

    public class AppConfig
    {
        public string? Environment { get; set; }
    }

    public interface IAppConfiguration
    {
        string GetValue(string settingName);
    }

}
