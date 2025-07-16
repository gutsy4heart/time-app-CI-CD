using LiteraHouse.Models;
using LiteraHouse.Repository.AddPost;
using LiteraHouse.Repository.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using Npgsql.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = "Host=postgres;Port=5432;Database=literaDB;Username=postgres;Password=postgres";
Console.WriteLine("📡 Строка подключения: " + connectionString);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
        .UseNpgsql(connectionString, sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        })
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
});

builder.Services.AddScoped<IBooksRepository, EFCoreBookRepository>();

var app = builder.Build();
if (args.Contains("migrate"))
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    return;
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
