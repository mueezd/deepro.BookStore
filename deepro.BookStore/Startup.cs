 using deepro.BookStore.Data;
using deepro.BookStore.Helper;
using deepro.BookStore.Models;
using deepro.BookStore.Repository;
using deepro.BookStore.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUserModel, IdentityRole>().
                AddEntityFrameworkStores<BookStoreDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.SignIn.RequireConfirmedEmail = true;

                options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(2);
                options.Lockout.MaxFailedAccessAttempts= 3;
            });


            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromMinutes(2);
            });

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = _config["Application:LoginPath"];
            });

            services.AddControllersWithViews();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUserModel>, ApplicationUserClaimsPrincipalFactory>();

            services.Configure<SMTPConfigModel>(_config.GetSection("SMTPConfig"));
            services.Configure<NewBookAlertConfig>("InternalBook",_config.GetSection("NewBookAlert"));
            services.Configure<NewBookAlertConfig>("ThirdPartyBook",_config.GetSection("ThirdPartyBook"));


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

            //app.Use(async (context, next) Routing, Attribute routing, Route constraints 
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();


                //endpoints.MapControllerRoute(
                //    name: "Default",
                //    pattern: "bookApp/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "MyArea",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
 