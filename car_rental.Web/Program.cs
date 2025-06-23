
using car_rental.Web.Extentions;
using car_rental.Web.UIService;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddAuthorization(options =>
{
    // You can define policies here if needed, but for simple role checks,
    // the [Authorize(Roles = "Admin")] attribute is sufficient.
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(o =>
{
    o.Password.RequireDigit = true;
    o.Password.RequireLowercase = true;
    o.Password.RequireUppercase = true;
    o.Password.RequireNonAlphanumeric = true;
    o.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});


builder.Services.AddControllersWithViews();


builder.Services.AddRazorPages(); // Add this line


// DI of Services Interfaces
builder.Services.AddScoped<IFeatureService,FeatureService>();
builder.Services.AddScoped<ICarService,CarService>();
builder.Services.AddScoped<IBookingService,BookingService>();
builder.Services.AddScoped<IBrandService>(provider =>
{
    // inject the IWebHostEnvironment in the services

    var env = provider.GetRequiredService<IWebHostEnvironment>();
    var repo = provider.GetRequiredService<IBrandRepository>();
    return new BrandService(repo, env.WebRootPath);
});

// DI of Repository Interfaces
builder.Services.AddScoped<IBrandRepository,BrandRepository>();
builder.Services.AddScoped<IFeatureRepository,FeatureRepository>();
builder.Services.AddScoped<ICarRepository,CarRepository>();
builder.Services.AddScoped<IBookingRepository,BookingRepository>();

// DI of UI Service
builder.Services.AddScoped<IFormOptionsService, FormOptionsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

await app.Services.IdentitySeeder();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();    // Needed for Identity Razor
                        
app.MapControllers();   // Needed for MVC Controllers

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


