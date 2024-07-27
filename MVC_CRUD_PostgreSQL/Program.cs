using Microsoft.EntityFrameworkCore;
using MVC_CRUD_PostgreSQL.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Contexto>(options => options.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=MVC_CRUD_PostgreSQL;User Id=postgres;Password:260274;"));

builder.Services.AddDbContext<Contexto>(options => options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=MVCCRUDPostgreSQL;User Id=postgres;Password=260274;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
