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

            builder.Services.AddDbContext<CartDbContext>(opt=>opt.UseSqlServer(@"Server=DESKTOP-N4A540V;Database=ConsultingDB;Trusted_Connection=True;TrustServerCertificate=True;"));

            builder.Services.AddScoped<CartService>();
            
            
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
