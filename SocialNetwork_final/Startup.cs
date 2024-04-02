using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SocialNetwork_final.Contract.Model;
using SocialNetwork_final.Contract.Validator;
using SocialNetwork_final.Controllers;
using SocialNetwork_final.DB;
using SocialNetwork_final.DB.Model;
using SocialNetwork_final.DB.Repository;
using System.Reflection;

namespace SocialNetwork_final
{
    public class Startup
    {
        public IConfiguration Configuration { get; } =
            new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .Build();

        public void ConfigureServices(IServiceCollection services)
        {

            var assembly = Assembly.GetAssembly(typeof(MapperProfile));
            services.AddAutoMapper(assembly);

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SocialNetworkContext>(option => option.UseSqlServer(connection), ServiceLifetime.Singleton);
            services.AddIdentity<User,IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<SocialNetworkContext>();

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserRequestValidator>());

            

            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseAuthorization();
            app.UseAuthentication();
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
