using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.HttpOverrides;
using WebDemo.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebDemo
{
    public class Startup
    {
        private IConfiguration config;

        public Startup(IConfiguration config) => this.config = config;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //change the connection string in the appsettings.json
            var connectionString = config.GetConnectionString("AppDBContext");

            // add the database service
            services.AddDbContext<AppDBContext>(options =>
                options.UseNpgsql(connectionString) // this is database specific 
            );

            // add the identity service
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDBContext>() // some IdentityDbContext
                .AddDefaultTokenProviders();

            services.AddAuthentication();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        "actionDefault",                                              // Route name
                        "{area:exists}/{controller}/{action}/{id}",                           // URL with parameters
                        new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
                    );
                routes.MapRoute(
                     "Default",                                              // Route name
                     "{controller}/{action}/{id}",                           // URL with parameters
                     new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
                 );
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
