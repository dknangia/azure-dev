using System.Net.Http.Headers;
using System.Diagnostics;
using System.Net;

namespace GeoLocationTestDataRequestAverage;

public class Process
{
    private readonly IAppConfiguration _configuration = new AppConfiguration();
    private readonly List<string?> _queries = new();


    public async Task Request(int requestCount, string indexName)
    {
        if (requestCount < 1) throw new ArgumentException("requestCount must be greater than 0");

        var endPoint = _configuration.GetValue("SearchService:EndPoint");
        var apiKey = _configuration.GetValue("SearchService:ApiKey");



        GetQueries(indexName);
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //httpClient.Timeout = TimeSpan.FromSeconds(10);
        httpClient.DefaultRequestHeaders.Add("api-Key", apiKey);

        await RunHttpRequests(indexName, requestCount, httpClient, endPoint);


    }

    private async Task RunHttpRequests(string indexName, int requestCount, HttpClient httpClient, string? endPoint)
    {
        Console.WriteLine($"Starting requests for {indexName}");
        double totalAverage = 0;
        int outerVar = 5;
        for (var outer = 0; outer < outerVar; outer++)
        {

            double average = 0;
            for (var i = 0; i < requestCount; i++)
            {
                var requestUrl = GenerateUrl(indexName, endPoint);
                var stopWatch = Stopwatch.StartNew();
                var response = await httpClient.GetAsync(requestUrl);
                stopWatch.Stop();
                //if (response?.StatusCode != HttpStatusCode.OK)
                //{
                //    Console.WriteLine($"Error: {response?.StatusCode}");
                //}   

              

                average += stopWatch.Elapsed.TotalMilliseconds;
            }

            average /= requestCount;
            Console.WriteLine($"{outer} Average time for {requestCount} requests: {average} ms");
            totalAverage += average;

        }

        totalAverage /= outerVar;
        Console.WriteLine($"Total Average time: {totalAverage} ms");
        Console.WriteLine("--End--");
        Console.WriteLine();
    }

    private void GetQueries(string? indexName)
    {
        _queries.Clear();
        switch (indexName)
        {
            case "qaads-virtualdealer" or "qaads-virtualcontroldealer":
                _queries.Add(_configuration.GetValue("Query:virtual:1"));
                _queries.Add(_configuration.GetValue("Query:virtual:2"));
                _queries.Add(_configuration.GetValue("Query:virtual:3"));
                _queries.Add(_configuration.GetValue("Query:virtual:4"));
                _queries.Add(_configuration.GetValue("Query:virtual:5"));
                break;
            case "qaads-control":
                _queries.Add(_configuration.GetValue("Query:control:1"));
                _queries.Add(_configuration.GetValue("Query:control:2"));
                _queries.Add(_configuration.GetValue("Query:control:3"));
                _queries.Add(_configuration.GetValue("Query:control:4"));
                _queries.Add(_configuration.GetValue("Query:control:5"));
                break;
            default:
                throw new ArgumentException("indexName must be qaads-virtualdealer or qaads-control");
        }
    }

    private string GenerateUrl(string? indexName, string? endPoint)
    {
        var random = new Random();
        var randomNumber = random.Next(0, _queries.Count);
        return $"{endPoint}/indexes/{indexName}/docs?api-version=2020-06-30{_queries[randomNumber]}";
    }
}