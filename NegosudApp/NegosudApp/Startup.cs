using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NegosudApp.Migrations;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;
using NegosudApp.PasswordHash;

namespace NegosudApp
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
			Env = env;
            Configuration = configuration;
        }

		public IWebHostEnvironment Env { get; }
        public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add
		// services to the container.
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

			//Add the services allowing to resolve service for type
			//'NegosudApp.PasswordHash.PwdHasher' while attempting to activate
			//'NegosudApp.Controllers.RegisterController'
            services.AddScoped<PwdHasher>();

            services.AddDefaultIdentity<IdentityUser>(options =>
            options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<NegosudDbContext>();

            services.AddControllersWithViews();

            services.AddCors();
            services.AddControllers();

			// configure Swagger
			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "server", Version = "v1" });
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
            });

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
            app.UseSwagger();
            app.UseSwaggerUI(c => {
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "server v1");
			});

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

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
