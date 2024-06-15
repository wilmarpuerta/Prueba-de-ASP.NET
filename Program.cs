using Microsoft.EntityFrameworkCore;
using Prueba_de_ASP.NET.Data;
using Prueba_de_ASP.NET.Services.Email;
using Prueba_de_ASP.NET.Services.Owners;
using Prueba_de_ASP.NET.Services.Pets;
using Prueba_de_ASP.NET.Services.Quotes;
using Prueba_de_ASP.NET.Services.Vets;
using Prueba_de_ASP.NET.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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


builder.Services.AddAutoMapper(typeof(OwnerProfile), typeof(PetProfile), typeof(QuoteProfile), typeof(VetProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAnyOrigin");

app.MapControllers();

app.Run();

