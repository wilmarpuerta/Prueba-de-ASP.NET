using Microsoft.EntityFrameworkCore;
using Prueba_de_ASP.NET.Data;
using Prueba_de_ASP.NET.Services.Email;
using Prueba_de_ASP.NET.Services.Owners;
using Prueba_de_ASP.NET.Services.Pets;
using Prueba_de_ASP.NET.Services.Quotes;
using Prueba_de_ASP.NET.Services.Vets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IOwnersRepository, OwnersRepository>();
builder.Services.AddScoped<IPetsRepository, PetsRepository>();
builder.Services.AddScoped<IVetsRepository, VetsRepository>();
builder.Services.AddScoped<IQuotesRepository, QuotesRepository>();
builder.Services.AddScoped<SendEmail>();


builder.Services.AddDbContext<BaseContext> (options => 
    options.UseMySql(
        builder.Configuration.GetConnectionString("MysqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

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

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAnyOrigin");

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
