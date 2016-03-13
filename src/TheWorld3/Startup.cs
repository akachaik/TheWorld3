using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Framework.Configuration;
using TheWorld3.Services;
using TheWorld3.Models;

namespace TheWorld3
{
    public class Startup
    {
        public static Microsoft.Extensions.Configuration.IConfiguration Configuration;
        public Startup()
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<WorldContext>();
            services.AddTransient<WorldContextSeedData>();

            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IWorldRepository, WorldRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, WorldContextSeedData seeder)
        {
            //app.UseIISPlatformHandler();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"Hello World: {context.Request.Path}");
            //});
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(config =>
            {
                config.MapRoute("Default", "{controller}/{action}/{id?}", new { controller = "App", action = "Index" });
            });

            seeder.EnsureSeedData();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
