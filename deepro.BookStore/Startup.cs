using deepro.BookStore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
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
            services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer("Data Source=192.168.0.11;Initial Catalog=BookStoreDb;User ID=sa;Password=AplectrumCloud1234$"));
            services.AddControllersWithViews();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
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

            app.UseStaticFiles();
  
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(
                //    name: "Default",
                //    pattern: "bookApp/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
 