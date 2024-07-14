using Admin.Repository;
using Admin.Service.Contract;
using Admin.Service;

namespace Admin.Extensions
{
    public static class ServiceInjectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            // Ajouter le repository générique
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Ajouter le service des bénéficiaires
            services.AddScoped<IBeneficiaryService, BenificierService>();

            // Ajouter le mapper des bénéficiaires
            //services.AddScoped<IBenificierMapper, BenificierMapper>();
        }
    }
}
