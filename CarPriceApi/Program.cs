var builder = WebApplication.CreateBuilder(args);

// Register the services
builder.Services.AddSingleton<ILogger>(provider => new Logger("log_CarPriceCalc.log"));
builder.Services.AddTransient<CarPriceFactory>();

// Add controllers
builder.Services.AddControllers(); // Add controller services

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