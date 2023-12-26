using ElectronicsDbApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database context
var dbHost = "mysql-db";
var dbName = "ELECTRONICS_DB";
var dbPassword = "PASSWORD";
var dbUser = "USER";

var connectionString = $"server={dbHost};port=3306;database={dbName};user={dbUser};password={dbPassword}";
builder.Services.AddDbContext<PartDbContext>(o => o.UseMySQL(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
