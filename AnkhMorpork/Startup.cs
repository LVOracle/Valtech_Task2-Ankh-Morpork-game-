using AnkhMorpork.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Valtech_Task2_Ankh_Morpork_game_;
using Valtech_Task2_Ankh_Morpork_game_.Data;
using Valtech_Task2_Ankh_Morpork_game_.Data.IRepository;
using Valtech_Task2_Ankh_Morpork_game_.Data.Repository;

namespace AnkhMorpork
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AccountContext>(options =>
                options.UseSqlServer(Configuration["Account:ConnectionString"]));

            services.AddIdentity<Player, IdentityRole>().AddEntityFrameworkStores<AccountContext>();

            services.AddControllersWithViews();

            services.AddTransient<IGeneralRepository, Repository>();

            services.AddDbContext<AnkhMorporkGameContext>(option => option.UseSqlServer(Configuration["Data:ConnectionString"]));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
