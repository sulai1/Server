using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using WebDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebDemo
{
    public class Startup
    {
        private IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = config.GetConnectionString("AppDBContext");
            services.AddDbContext<AppDBContext>(options => 
                options.UseSqlServer(connectionString)
            );
            services.AddMvc(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
