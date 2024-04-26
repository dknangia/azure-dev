using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Versioning;

namespace ClientConnectionsTLS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunProgram();
        }

        private static void RunProgram()
        {
            var targetFrameworkAttribute = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), false)
                .SingleOrDefault();

            var targetFramework = (TargetFrameworkAttribute)targetFrameworkAttribute;
            Console.WriteLine($"{targetFramework?.FrameworkDisplayName}");
            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
                Console.WriteLine($"{ServicePointManager.SecurityProtocol}");
                var url = "https://www.howsmyssl.com/a/check";
                var response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"{url} {response.StatusCode} {content}");
            }

            Console.ReadLine();
        }
    }
}
