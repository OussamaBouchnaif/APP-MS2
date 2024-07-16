using Admin.Repository;
using Admin.Service.Contract;
using Admin.Service;
using Admin.Mapper.Contract;
using Admin.Mapper;

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
            services.AddScoped<IBenificierMapper, BenificierMapper>();
            // Ajouter le service des bénéficiaires

            services.AddScoped<IUtilisateurMapper, UtilisateurMapper>();

            // Ajouter le mapper des bénéficiaires
            services.AddScoped<IUtilisateurService, UtilisateurService>();

            // Enregistrer le service de gestion des utilisateurs
            services.AddScoped<IUserIdentityService, UserIdentityService>();
        }
    }
}