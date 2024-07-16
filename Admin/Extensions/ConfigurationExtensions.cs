using Admin.Models;
using Microsoft.AspNetCore.Identity;
using MS2Api.Data;
using MS2Api.Model;

namespace Admin.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationBuilder AddCustomConfiguration(this IConfigurationBuilder builder, IWebHostEnvironment env)
        {
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                   .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables();

            return builder;
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<Personne, Role>()
                .AddEntityFrameworkStores<MyContext>()
                .AddDefaultTokenProviders();
        }
    }
}