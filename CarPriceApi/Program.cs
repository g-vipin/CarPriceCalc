using CarPriceApi.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Register the services
builder.Services.AddSingleton<CarPriceApi.Services.ILogger>(provider => new Logger("log_CarPriceCalc.log"));
builder.Services.AddTransient<CarPriceFactory>();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddJsonFile("appsettings.api.json", optional: true, reloadOnChange: true)
.AddJsonFile("appsettings.api.Development.json", optional: true, reloadOnChange: true);
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
  {
    Title = "Car Price API",
    Version = "v1"
  });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
      options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
      options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
  options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
  options.RoutePrefix = string.Empty; // Serve Swagger UI at the application root.
});

app.UseHttpsRedirection();
app.MapControllers();  // Map controllers to routes

app.Run();