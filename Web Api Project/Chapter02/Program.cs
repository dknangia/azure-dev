
using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using Chapter02;
using Chapter02.Models;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<IceCreamDb>(options => options.UseInMemoryDatabase("icecreams"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new()
{
    Title = builder.Environment.ApplicationName,
    Version = "v1",
    Contact = new()
    {
        Email = "dknangia@gmail.com",
        Name = "Deepak",
        Url = new Uri("https://nowhere.com")
    }
}));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

/*Adding default cors policy*/
var corsPolicy = new CorsPolicyBuilder("http://localhost:5200")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .Build();

var corsPolicyForWeb2 = new CorsPolicyBuilder("http://localhost:5100")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .Build();


Registration(builder);

void Registration(WebApplicationBuilder? webBuilder)
{
    if (webBuilder == null) return;
    webBuilder.Services.AddScoped<IWeatherService, WeatherService>();
    
}



// Adding policy to entire application
//webBuilder.Services.AddCors(x => x.AddDefaultPolicy(corsPolicy));

//Adding custom policy

builder.Services.AddCors(c => c.AddPolicy("MyCustomPolicy", corsPolicyForWeb2));

builder.Services.TryAddSingleton<IActionResultExecutor<ObjectResult>, ProblemDetailsResultExecutor>();

builder.Services.AddProblemDetails(options =>
{
    options.MapToStatusCode<NotImplementedException>(StatusCodes.Status501NotImplemented);
});

var app = builder.Build();
app.UseProblemDetails();

/*Error handling*/

/*
app.UseExceptionHandler(exceptionHandlerApp =>
{

    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = MediaTypeNames.Application.Json;

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>()!;

        var errorMessage = new
        {
            exceptionHandlerPathFeature.Error.Message
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(errorMessage));
        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
        {
            await context.Response.WriteAsync("The file is not found");

        }

        if (exceptionHandlerPathFeature?.Path == "/")
        {
            await context.Response.WriteAsync("Page : Home");
        }
    });
});
*/



app.UseCors("MyCustomPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapEndpoints(Assembly.GetExecutingAssembly());


app.MapGet("/weatherforecast", (IWeatherService service) => service.GetForecast())
.WithName("GetWeatherForecast");


app.MapGet("/hello", async (IConfiguration configuration) =>
{
    var s = configuration.GetValue<string>("MyCustoms:Section1");
    await Task.Delay(100);
    return Results.Ok(s);

}).RequireCors("MyCustomPolicy"); //Applying cors to specific endpoint

//var handler = () => "[Lambda variable] Hello world";
var handler = () =>
{
    throw new ArgumentException("Internal error", $"Internal error message");
};

app.MapGet("/hello-inline", handler).Produces<ProblemDetails>(statusCode: StatusCodes.Status500InternalServerError).WithName("Internal Server ERROR");

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

public record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}