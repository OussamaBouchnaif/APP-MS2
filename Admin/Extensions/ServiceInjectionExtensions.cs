using Admin.Builder;
using Admin.Builder.Contract;
using Admin.Mapper;
using Admin.Mapper.Contract;
using Admin.Repository;
using Admin.Service;
using Admin.Service.Contract;
using Microsoft.AspNetCore.Identity;
using MS2Api.Model;

namespace Admin.Extensions
{
    public static class ServiceInjectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            // Ajouter le repository générique
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Ajouter le service des bénéficiaires
            services.AddScoped<IBeneficiaryService, BeneficiaryService>();

            // Ajouter le mapper des bénéficiaires
            services.AddScoped<IBenificierMapper, BenificierMapper>();
            // Ajouter le service des bénéficiaires

            services.AddScoped<IUtilisateurMapper, UtilisateurMapper>();

            // Ajouter le mapper des bénéficiaires
            services.AddScoped<IUtilisateurService, UtilisateurService>();

            // Enregistrer IHttpContextAccessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Enregistrer IPasswordHasher
            services.AddScoped<IPasswordHasher<Utilisateur>, PasswordHasher<Utilisateur>>();

            services.AddScoped<AuthenticationFilter>();

            // Enregistrer IVeilleContextuelleService
            services.AddScoped<IVeilleContextuelleService, VeilleContextuelleService>();

            // Enregistrer IVeilleContextuelleMapper
            services.AddScoped<IVeilleContextuelleMapper, VeilleContextuelleMapper>();

            services.AddScoped<INotificationService, NotificationService>();

            services.AddScoped<IDossierService, DossierService>();

            services.AddScoped<IDossierMapper, DossierMapper>();

            services.AddScoped<IDossierPersonnelBuilder, DossierPersonnelBuilder>();

            services.AddScoped<IMedicalService,MedicalService>();
            services.AddScoped<IMedicalMapper,MedicalMapper>();
            services.AddScoped<IAvisService,AvisService>();

        }
    }
}