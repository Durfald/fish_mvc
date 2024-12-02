using System.Net;
using fish_mvc.Infrastructure.DatabaseManagement;
using fish_mvc.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseConnection>((options) => { 
    options.UseSqlite(builder.Configuration.GetConnectionString("con"));
});

#region  Roles

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, ops =>
    {
        ops.AccessDeniedPath = "/Auth/AccessDenied";
        ops.LoginPath = "/Auth/Login";
        ops.LogoutPath = "/Auth/Logout";
        ops.ExpireTimeSpan = TimeSpan.FromDays(2);
        ops.SlidingExpiration = true;
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("admin", ops =>
    {
        ops.RequireRole("admin");
    });

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseConnection>();
    dbContext.Database.EnsureCreated();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
