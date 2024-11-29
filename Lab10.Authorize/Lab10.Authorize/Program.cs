
using Lab10.Authorize;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication("DevSecuritySchema").AddCookie("DevSecuritySchema", opt =>
{
    opt.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = "Devmaster.Security.Cookie",
        Path = "/",
        SameSite=SameSiteMode.Lax,
        SecurePolicy=CookieSecurePolicy.SameAsRequest
    };
    opt.LoginPath = new PathString("/Home/Login");
    opt.SlidingExpiration= true;
});
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
