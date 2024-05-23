using Microsoft.EntityFrameworkCore;
using TpFinal.Data;

namespace TpFinal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();  // Ajout des services MVC

            // Add DbContext
            builder.Services.AddDbContext<HeroContext>(
                options => {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("BDHero"));
                    options.UseLazyLoadingProxies();
                });

            var app = builder.Build();

            // Middleware configuration
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Heroes}/{action=Index}/{id?}"
                );
                endpoints.MapRazorPages();  // Map Razor Pages
            });

            app.Run();
        }
    }
}
