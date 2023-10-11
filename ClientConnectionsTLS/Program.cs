using System;
using System.Net;
using System.Net.Http;

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
            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
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
