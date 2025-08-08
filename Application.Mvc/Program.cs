using Application.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<ApplicationnDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    options.UseSqlServer(connectionString);
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "bookvoting-cookie";
        options.Cookie.IsEssential = true;
        options.Cookie.HttpOnly = true;

        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // geçerlilik süresi

        options.LoginPath = "/Auth/Login"; // Login olmamýþ kiþi nereye yönlendrilsin.

        options.AccessDeniedPath = "/Auth/AccessDenied"; // yetkisiz giriþlerde buraya yönlendirilsin...

    });


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

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationnDbContext>();


    if (await dbContext.Database.EnsureCreatedAsync())
    {
        // DbSeed

        await SeedData.SeedAsync(dbContext);
    }
}


app.Run();
