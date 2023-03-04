using System.Reflection;
using Chapter02;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>c.SwaggerDoc("v1", new()
{
    Title = builder.Environment.ApplicationName, 
    Version = "v1", Contact = new()
    {
        Email = "dknangia@gmail.com", 
        Name = "Deepak", 
        Url = new Uri("https://nowhere.com")
    }
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapEndpoints(Assembly.GetExecutingAssembly());

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");


app.MapGet("/hello", async () =>
{
    await Task.Delay(100);
    return "Map GET => Response";

});

var handler = () => "[Lambda variable] Hello world";

app.MapGet("/hello-inline", handler);

var hello = new HelloHandler();

app.MapGet("/hello-instance", hello.Hello);

app.MapPost("/hello", async () =>
{
    await Task.Delay(100);

});


/*Router parameters*/

app.MapGet("/users/{username:int}/products/{productId:guid}",
    (int username, Guid productId) =>

        $"The username is {username} and the productId is {productId}"

    );


/*Query parameter binding*/
app.MapGet("/search", ([FromQuery(Name = "q")] string searchText, [FromQuery(Name = "id")] string id) =>

    $"Query string parameters are ID {id} and Search term : {searchText}"
);

app.MapGet("/people", (int pageIndex, int itemsPerPage) =>
    $"Sample result for page: {pageIndex}, and pageSize : {itemsPerPage}"
);


/*Biding default values to query parameter*/
string SearchMethod(int pageIndex = 0, int pageSize = 50) =>
    $"Sample result for page: {pageIndex}, and pageSize : {pageSize}";

app.MapGet("/people-result", SearchMethod);

/*Custom bindings*/


// GET /navigate?location=43.8427,7.8527
app.MapGet("/navigate", (Location location) => 
    $"Location Longitude : {location.Longitude}, and Latitude : {location.Latitude}");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}