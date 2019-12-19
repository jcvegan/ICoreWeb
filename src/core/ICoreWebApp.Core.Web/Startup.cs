using ExtCore.WebApplication.Extensions;
using ICoreWeb.Data.Identity.Service.Initializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ICoreWebApp.Core.Web
{
    public class Startup
    {
        private readonly string _extensionPath = string.Empty;

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _extensionPath = environment.ContentRootPath + configuration["Extensions:Path"];
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCoreServices(options => options.UseSqlite("Data Source=Identity.db;"));
            services.AddExtCore(_extensionPath);
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("defaultIdentity", "Identity", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });

            app.UseExtCore();
        }
    }
}
