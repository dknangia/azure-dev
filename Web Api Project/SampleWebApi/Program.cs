var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

else if (app.Environment.IsProduction())
{
    //todo : Add production logic over here 
}

else if (app.Environment.IsStaging())
{
    // todo : Add staging logic over here
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
