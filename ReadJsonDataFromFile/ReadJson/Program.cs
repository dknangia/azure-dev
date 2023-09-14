// See https://aka.ms/new-console-template for more information

using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

string[] randomLocations =
{
    "{\r\n\"type\": \"Point\",\r\n\"coordinates\": [\r\n\t-75.729973,\r\n\t45.3647\r\n\t\t\t\t],\r\n\"crs\": {\r\n\t\"type\": \"name\",\r\n\t\"properties\": {\r\n\t\"name\": \"EPSG:4326\"\r\n\t}",
    "{\r\n\"type\": \"Point\",\r\n\"coordinates\": [\r\n\t-81.15107,\r\n\t43.01297\r\n\t\t\t\t],\r\n\"crs\": {\r\n\t\"type\": \"name\",\r\n\t\"properties\": {\r\n\t\"name\": \"EPSG:4326\"\r\n\t}",
    "{\r\n\"type\": \"Point\",\r\n\"coordinates\": [\r\n\t-79.40007,\r\n\t43.708279\r\n\t\t\t\t],\r\n\"crs\": {\r\n\t\"type\": \"name\",\r\n\t\"properties\": {\r\n\t\"name\": \"EPSG:4326\"\r\n\t}"
};

ReadJsonData();



int GenerateRandomNumber()
{
    return new Random().Next(0, 3);
}

void ReadJsonData()
{
    int counter = 0;
    using StreamReader reader = File.OpenText(@"C:\export-ads.json\for_sql.json");
    StringBuilder sb = new StringBuilder();
    ;
    JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
    {
        var d = from p in o["value"]
                select p;
        foreach (var j in d)
        {
            if (counter > (j.Count() / 4))
                break;

            sb.Append($"{{\r\n\"@search.action\": \"upload\"," +
                              $"\r\n\"Id\": {j["Id"]}," +
                              $"\r\n\"SearchLocations\":[{j["Location"]}," +
                              $"{randomLocations[GenerateRandomNumber()]}" +
                              $"}}}}]}},");
        }
    }

    File.WriteAllText(@"C:\export-ads.json\for_sql_output.json", sb.ToString());
}