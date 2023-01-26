using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deepro.BookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello form First MiddleWare");
            //    await next();
            //    await context.Response.WriteAsync("\tHello form First MiddleWare response");

            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("\tHello form Second MiddleWare");
            //    await next();
            //    await context.Response.WriteAsync("\tHello form Second MiddleWare response");
            //});



            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("\tHello form third MiddleWare");
            //    await next();
            //});
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });



        }
    }
}