using CarPriceApi.Services;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Register the services
builder.Services.AddSingleton<CarPriceApi.Services.ILogger>(provider => new Logger("log_CarPriceCalc.log"));
builder.Services.AddTransient<CarPriceFactory>();

// Add controllers
builder.Services.AddControllers()
    .AddNewtonsoftJson( opt =>
    {
      opt.SerializerSettings.ContractResolver = new DefaultContractResolver()
      {
        NamingStrategy = new SnakeCaseNamingStrategy()
      };
    } );


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();  // Map controllers to routes

app.Run();