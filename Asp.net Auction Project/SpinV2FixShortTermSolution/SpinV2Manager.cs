using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace SpinV2FixShortTermSolution
{
    public class SpinV2Manager
    {
        public HttpClient Client { get; }
        private readonly IAppConfiguration _configuration;
        public SpinV2Manager()
        {
            _configuration = new AppConfiguration();
            Client = new HttpClient();
        }

        public async Task ProcessRecords()
        {
            var data = ReadingSpinQueryData();
            if (data is { Count: > 0 })
            {
                StringBuilder builder = new StringBuilder();
                foreach (var spinQueryData in data)
                {
                    var apiUrl = GenerateImpelApiUrl(spinQueryData.Vin);

                    //var httpClient = new HttpClient();
                    //var response = await httpClient.GetAsync(apiUrl, default(CancellationToken)).ConfigureAwait(false);

                    //if (response.StatusCode == HttpStatusCode.OK)
                    //{
                        // 2003930105649706,51529901,W1KWF8EB9MR630141
                        builder.AppendLine($"{spinQueryData.CompanyId}, {spinQueryData.AdId}, {spinQueryData.Vin}");
                    //}

                }

                WriteToCsvFile(builder);
                PostDataToAzureFunction();

            }
        }

        private static void PostDataToAzureFunction()
        {
            var filePath = $@".\..\..\..\InputDataForPostman-{DateTime.Now:yyyy-dd-M}.csv";
            if (!File.Exists(filePath)) return;
            var data = new List<SpinQueryData>();

            using var rd = new StreamReader(@".\..\..\..\SpinQueryData.csv");
            while (!rd.EndOfStream)
            {
                var splits = rd.ReadLine()?.Split(',');
                if (splits != null)
                {

                    data.Add(new SpinQueryData()
                    {
                        CompanyId = splits[0],
                        AdId = splits[1],
                        Vin = splits[2]
                    });

                }
            }

            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    if (item.Vin == null)
                    {
                        //Call new API 
                    }   
                }
            }
        }


        /// <summary>
        /// Write only those records which has data
        /// </summary>
        /// <param name="builder"></param>
        private void WriteToCsvFile(StringBuilder builder)
        {
            if (builder.Length <= 0) return;
            var filePath = $@".\..\..\..\InputDataForPostman-{DateTime.Now:yyyy-dd-M}.csv";
            if (File.Exists(filePath))
                File.Delete(filePath);
            File.WriteAllText(filePath, builder.ToString());
        }

        public List<SpinQueryData> ReadingSpinQueryData()
        {
            var data = new List<SpinQueryData>();

            using var rd = new StreamReader(@".\..\..\..\SpinQueryData.csv");
            while (!rd.EndOfStream)
            {
                var splits = rd.ReadLine()?.Split(',');
                if (splits != null)
                {

                    data.Add(new SpinQueryData()
                    {
                        CompanyId = splits[0],
                        AdId = splits[1],
                        Vin = splits[2]
                    });

                }
            }

            return data;
        }

        public string GenerateImpelApiUrl(string? vin, CancellationToken token = default)
        {
            if (string.IsNullOrWhiteSpace(vin)) return string.Empty;
            var apiKey = _configuration.GetValue("Spin:Impel:ApiKey");
            var cid = _configuration.GetValue("Spin:Impel:CID");
            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(cid)) return string.Empty;
            var stringToHash = $"{apiKey}{cid}{vin}";
            var auth = GetImpelHash(stringToHash);
            if (string.IsNullOrEmpty(auth))
                throw new Exception($"Auth is null for the VIN : {vin}");
            return $"{_configuration.GetValue("Spin:Impel:ApiBaseUrl")}?auth={auth}&cid={cid}&vin={vin}&raw=y&wa_360=y";

        }

        internal static string GetImpelHash(string convertToHash)
        {
            if (string.IsNullOrWhiteSpace(convertToHash)) return string.Empty;
            var bytes = Encoding.UTF8.GetBytes(convertToHash);
            var sha512Object = SHA512.Create();
            sha512Object.ComputeHash(bytes);
            if (sha512Object.Hash != null)
                return sha512Object.Hash.Aggregate(string.Empty, (current, x) => current + $"{x:x2}");
            return string.Empty;
        }
    }


    public class SpinQueryData
    {
        public string? CompanyId { get; set; }
        public string? AdId { get; set; }
        public string? Vin { get; set; }
    }

    public static class SpinV2Program
    {
        public static async void Run()
        {
            await new SpinV2Manager().ProcessRecords();
        }
    }
}
