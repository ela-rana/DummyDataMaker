using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DummyDataMaker.Models;
using DummyDataMaker.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Lockout.MaxFailedAccessAttempts = 10;
}).AddEntityFrameworkStores<UserContext>();
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(
    "Server=ELAPC;Database=DummyDBUser;Trusted_Connection=true;MultipleActiveResultSets=True"));

builder.Services.AddDbContext<DataPoolContext>(options => options.UseSqlServer(
    "Server=ELAPC;Database=DummyDBDataPool;Trusted_Connection=true;MultipleActiveResultSets=True"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

using (var scope = app.Services.CreateScope())
{
    var userDbContext = scope.ServiceProvider.GetRequiredService<UserContext>();
    //userDbContext.Database.EnsureDeleted();
    userDbContext.Database.EnsureCreated(); //creates the database if it doesn't already exist

    var dataPoolContext = scope.ServiceProvider.GetRequiredService<DataPoolContext>();
    //dataPoolContext.Database.EnsureDeleted();
    dataPoolContext.Database.EnsureCreated(); //creates the database if it doesn't already exist
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); //to check user credentials and ensure right user

//Authentication must be before authorization, we have to already be authenticated
//so we can check if the logged in user has authorization

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
