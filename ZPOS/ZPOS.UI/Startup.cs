using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using ZPOS.UI.Context;
using ZPOS.UI.Entities;
using ZPOS.UI.Interfaces;
using ZPOS.UI.Repositories;
using ZPOS.UI.Services;

namespace ZPOS.UI
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
            services.AddDbContext<ZposContext>(options => options.UseSqlServer(Configuration.GetConnectionString("zpostdb")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ZposContext>();


            //configurando las opciones de IdentityUser
            services.Configure<IdentityOptions>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequiredUniqueChars = 0;
                config.Password.RequiredLength = 6;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
            });

            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<IProductServices, ProductServices>();

            services.AddScoped<IBrand, BrandRepository>();
            services.AddScoped<IBrandServices, BrandServices>();

            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<ICategoryServices, CategoryServices>();

            services.AddScoped<IClient, ClientRepository>();
            services.AddScoped<IClientServices, ClientServices>();

            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IUserServices, UserServices>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
