using Microsoft.EntityFrameworkCore;
using MS2Api.Model;

namespace MS2Api.Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Benificier> Benificier { get; set; }
        public DbSet<Utilisateur> Utilisateur { get; set; }
        public DbSet<DossierPersonnel> DossierPersonnel { get; set; }
        public DbSet<ParcoursMigratoire> ParcoursMigratoire { get; set; }
        public DbSet<Personne> Personne { get; set; }
        public DbSet<SituationAdministrative> SituationAdministrative { get; set; }
        public DbSet<SituationFamiliale> SituationFamiliale { get; set; }
        public DbSet<SituationPsychologique> SituationPsychologique { get; set; }
        public DbSet<SituationSocioEconomique> SituationSocioEconomique { get; set; }
        public DbSet<SituationViolence> SituationViolence { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurer les noms des tables pour TPH
            modelBuilder.Entity<Personne>()
                .ToTable("Personnes")
                .HasDiscriminator<string>("PersonneType")
                .HasValue<Benificier>("Benificier")
                .HasValue<Utilisateur>("Utilisateur");

        }

    }
}
