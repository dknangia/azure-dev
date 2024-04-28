using System;
using System.Net.Http;
using System.Net;

namespace Core31ConnectionTLS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine($"Application .NET framework : {System.Environment.Version.ToString()}");
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
                Console.WriteLine($"Current Security Protocol :  {ServicePointManager.SecurityProtocol}");
                var url = "https://www.howsmyssl.com/a/check";
                var response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"{url} {response.StatusCode} {content}");

            }

            Console.ReadLine();
        }
    }
}
