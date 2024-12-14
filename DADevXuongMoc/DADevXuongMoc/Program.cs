using DADevXuongMoc.Models;
using Microsoft.EntityFrameworkCore;

namespace DADevXuongMoc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration.GetConnectionString("AppConnectionString");
            builder.Services.AddDbContext<DevXuongMocContext>(x => x.UseSqlServer(connectionString));

            // Cấu hình sử dụng session
            builder.Services.AddDistributedMemoryCache();

            // Cấu hình Cookie Authentication
            builder.Services.AddAuthentication("DevSecuritySchema")
                .AddCookie("DevSecuritySchema", options =>
                {
                    options.Cookie.Name = "Devmaster.Security.Cookie"; // Tên cookie
                    options.Cookie.HttpOnly = true; // Bảo vệ cookie chỉ truy cập qua HTTP
                    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Yêu cầu HTTPS nếu request là HTTPS
                    options.Cookie.SameSite = SameSiteMode.Lax; // Chính sách SameSite
                    options.Cookie.Path = "/"; // Phạm vi áp dụng của cookie

                    options.LoginPath = "/Home/Login"; // Đường dẫn đến trang đăng nhập
                    options.LogoutPath = "/Home/Logout"; // Đường dẫn đến trang đăng xuất
                    options.AccessDeniedPath = "/Home/AccessDenied"; // Đường dẫn khi không có quyền truy cập (tùy chọn)

                    options.SlidingExpiration = true; // Gia hạn thời gian sống của cookie khi hoạt động
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Thời gian hết hạn của cookie
                });



            // Cấu hình Authorization (ủy quyền)
            builder.Services.AddAuthorization();

            // Đăng ký dịch vụ cho HttpContextAccessor
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Name = "Devmaster.Session";
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

            //sdung authentication
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            // Sử dụng session đã khai báo ở trên
            app.UseSession();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
