using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityProject.Areas.Identity.Data;
using System.Configuration;
var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DbContextSampleConnection") ?? throw new InvalidOperationException("Connection string 'DbContextSampleConnection' not found.");

builder.Services.AddDbContext<DbContextSample>(options => options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<IdentityProjectUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<DbContextSample>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
