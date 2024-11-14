// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.Json;
using EncryptedData;
using EncryptedData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Reflection;

WriteLine("Encrypted data");


//var hoursDifference = DateTime.UtcNow - new DateTime(2024, 2, 2,9,47,0);
//Console.WriteLine(hoursDifference);



//var todayDate = DateTime.UtcNow;

//WriteLine("todayDate : "+ todayDate);

//var past73Hours = todayDate.AddHours(-73);
//WriteLine("past73hours : "+ past73Hours);


//var past31DaysAddHours = todayDate.AddDays(-31);
//WriteLine("past31DaysAddHours : " + past31DaysAddHours);

//var dateInDb = new DateTime(2024, 2, 21, 9, 47, 0);
//WriteLine(dateInDb);

//WriteLine("Result : Is record 72 hours older");
//WriteLine(todayDate >= dateInDb);

//var isExpired = false;
//var _currentDateTime = DateTime.UtcNow;
//DateTime? CreatedDateTime = DateTime.UtcNow;

//isExpired = !(CreatedDateTime > _currentDateTime.AddDays(-365)
//         && CreatedDateTime <= _currentDateTime);
//Console.WriteLine(isExpired);


//var s = DateTime.Now.ToString("dd mmmm, yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"));
//nsole.WriteLine(s);

//string[] eng = {"janvier", "février", "mars", "avril", "mai", "juin", "juillet", "août", "septembre", "octobre", "novembre",
//    "décembre"};


//string[] fr = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November",
//    "December"};

//Console.WriteLine(new DateTime(2024, 03, 26).ToString("MMMM dd, yyyy", new CultureInfo("en-CA")));
//Console.WriteLine(new DateTime(2024, 03, 26).ToString("MMMM dd, yyyy", new CultureInfo("fr-FR")));

//Console.WriteLine(new DateTime(2024, 03, 26).ToString("yyyy-MM-dd"));


CallMethod();



Console.WriteLine(ToDescription(Category.VeryGood));        

string ToDescription(Enum value)
{
    FieldInfo field = value.GetType().GetField(value.ToString());
    DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
    return attribute == null ? value.ToString() : attribute.Description;
}

void CallMethod()
{
    var category = Enum.GetValues(typeof(Category));
}
public enum Category

{
    [Description("Excellent")]
    Excellent,

    [Description("Very Good")]
    VeryGood,

    [Description("Good")]
    Good,

    [Description("Fair")]
    Fair,

    [Description("Poor")]
    Poor,

}





//DateTime.TryParse("23/03/2024".ToString("MMMM dd, yyyy", new CultureInfo("fr-FR")));


//Regex regex = new Regex(@"[\d]+");
//var matchCollection = regex.Matches(("$53,000 up to").Replace(",", "").Replace(" ", ""));

//var match = matchCollection[0].Value;

//Console.WriteLine(match);
//foreach (Match match in matchCollection)
//{
//    Console.WriteLine(match.Value);
//}


//void AddServices(IServiceCollection services)
//{
//    services.AddDbContext<SportsStoreDBContext>(options =>
//    {

//        //options.UseSqlServer("Server=TCWLPF2GD13M;Database=SportsStore;Persist Security Info=False;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=True;Column Encryption Setting=enabled;MultipleActiveResultSets=False;Encrypt=True;Connection Timeout=30;");

//        options.UseSqlServer("Server=TCWLPF2GD13M;Database=SportsStore;Persist Security Info=False;User Id=sports_db_user; Password=P@ssw0rd12345678;TrustServerCertificate=True;Column Encryption Setting=enabled;MultipleActiveResultSets=False;Encrypt=True;Connection Timeout=30;");

//    });
//}

//var services = new ServiceCollection();

//AddServices(services);

//var dbContext = new SportsStoreDBContext(services.BuildServiceProvider().GetRequiredService<DbContextOptions<SportsStoreDBContext>>());

//try
//{

//    var products = dbContext.Products.ToList();
//    Console.WriteLine("Name\t\t\tPrice");
//    int i = 0;
//    foreach (var product in products)
//    {
//        Console.WriteLine($"{i++}.");
//        Console.WriteLine($"{product.Name}\t\t{product.Price}");
//        var x = JsonSerializer.Deserialize<JsonProduct>(product.JsonData);
//        Console.WriteLine($"\t{x?.Name} <--> {x?.Description}");
//        Console.WriteLine("");
//    }
//}
//catch (Exception e)
//{
//    Console.WriteLine(e);
//    throw;
//}

//var json = new JsonProduct()
//{
//    Description = "Lorem Ipsum",
//    Name = "KUERST 1986",
//};

//var newProduct = new Product()
//{

//    Name = $"KUERST {DateTime.Now.ToString(CultureInfo.InvariantCulture)}",
//    Description = "Mechanical Watch 1986 With DG Movement",
//    Price = 95.87M,
//    Category = "Loreum Ipsum",
//    //JsonData2 = json,
//    JsonData = JsonSerializer.Serialize(json)



//};

//try
//{
//    //var toUpdate = dbContext.Products.Where(x => x.ProductId == 8);
//    //toUpdate.First().Name = "KUERST 1986-2";
//    //toUpdate.First().Description = "Mechanical Watch 1986 With DG Movement";
//    //toUpdate.First().Price = 45.87M;
//    //toUpdate.First().Category = "Loreum Ipsum";

//    //dbContext.SaveChanges();

//    //dbContext.Products.Add(newProduct);
//    //dbContext.SaveChanges();
//    //Console.WriteLine("Product is saved.");
//}
//catch (Exception e)
//{
//    Console.WriteLine(e);
//    throw;
//}


//// JsonProduct Deserialize(Product product)
////{
////    if (product != null)
////    {
////        var json = JsonSerializer.Deserialize<JsonProduct>(product.JsonData);
////        return json;
////    }   
////}