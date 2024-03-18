using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SocialNetwork_final.Contract.Model;
using SocialNetwork_final.Contract.Validator;
using SocialNetwork_final.Controllers;
using SocialNetwork_final.DB;
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

            services.AddSingleton<IUserRepository, UserRepository>();
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SocialNetworkContext>(option => option.UseSqlServer(connection), ServiceLifetime.Singleton);

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserRequestValidator>());

            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

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
