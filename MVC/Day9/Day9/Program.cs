using Day9.Models;
using Day9.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Day9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Day9DbContext>();
            builder.Services.AddDbContext<Day9DbContext>(options => options.UseSqlServer(@"Data Source=DESKTOP-4EKG6BP\SQL2022;
                    Initial Catalog=Day9;
                    Integrated Security=SSPI;
                    TrustServerCertificate=True;"));
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

            app.UseAuthentication();// Check Cookie
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseStatusCodePagesWithRedirects("~/Registration/Login");

            app.Run();
        }
    }
}