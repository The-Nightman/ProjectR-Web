using Microsoft.EntityFrameworkCore;
using ProjectR_Web.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseMySql(
        connString
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' not found."
            ),
        ServerVersion.AutoDetect(connString)
    )
);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
