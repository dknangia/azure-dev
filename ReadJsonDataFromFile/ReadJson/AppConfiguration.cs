using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ReadJson
{
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        public string? GetValue(string key)
        {
            return this._configuration[key];
        }
    }

    public interface IAppConfiguration
    {
        string? GetValue(string key);
    }
}
