using Microsoft.EntityFrameworkCore;
using ProjectBL.Services;
using ProjectDAL.Contexts;

namespace ProjectMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDBContext>(opt=>opt.UseSqlServer(@"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=CourseDB;Trusted_Connection=True;TrustServerCertificate=True;"));
            builder.Services.AddScoped<CourseCartService>();


            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );


            app.MapControllerRoute(
                name:"default",
                pattern:"{controller=Home}/{action=Index}"
                );
            app.Run();
        }
    }
}
