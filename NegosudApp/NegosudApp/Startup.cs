using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NegosudApp.Data;
using NegosudApp.PasswordHash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegosudApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
//Less password requirements during development :
            //services.AddIdentity<IdentityUser, IdentityRole>(option =>
            //{
            //    option.Password.RequiredLength = 1;
            //    option.Password.RequireDigit = false;
            //    option.Password.RequireUppercase = false;
            //    option.Password.RequireNonAlphanumeric = false;
            //});

            ////Manage cookie for authorization
            //services.ConfigureApplicationCookie(option =>
            //{
            //    option.Cookie.Name = "Identity.Cookie";
            //    option.Cookie.Path = "/Home/Login";
            //});

//Add connection string to NegosudDbContext :
            services.AddDbContext<NegosudDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("NegosudConStr")));

            //services.AddDatabaseDeveloperPageExceptionFilter();

//Add the services allowing to resolve service for type 'NegosudApp.PasswordHash.PwdHasher'...
//... while attempting to activate 'NegosudApp.Controllers.RegisterController'
            services.AddScoped<PwdHasher>();

            services.AddDefaultIdentity<IdentityUser>(options =>
            options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<NegosudDbContext>();

            services.AddControllersWithViews();
        }

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
