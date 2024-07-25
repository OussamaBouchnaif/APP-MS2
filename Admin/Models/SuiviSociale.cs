using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class SuiviSociale
    {
        [Key]
        public int Id { get; set; }

        public bool? DemandeInfo { get; set; }
        public bool? PMSuivi { get; set; }
        public bool? PMNouvelle { get; set; }
        public bool? HebergementSuivi { get; set; }
        public bool? HebergementNouvelle { get; set; }
        public bool? ApuiSuivi { get; set; }
        public bool? ApuiNouvelle { get; set; }
        public bool? KitsAlimentationSuivi { get; set; }
        public bool? KitsAlimentationNouvelle { get; set; }
        public bool? ApuiSocioprofessionnelSuivi { get; set; }
        public bool? ApuiSocioprofessionnelNouvelle { get; set; }
        public string? autre1 { get; set; }
        public string? Informations { get; set; }
        public bool? DiscussionPlanDeSuite { get; set; }
        public DateTime? DateEntreeHebergement { get; set; }
        public bool? DistributionDeKit { get; set; }
        public string? DistributionDeKitDesc { get; set; }
        public bool? Accompagnement { get; set; }
        public string? AccompagnementPhysique { get; set; }
        public string? Orientation { get; set; }
        public bool? ReferencementExterne { get; set; }
        public bool? ReferencementIntern { get; set; }
        public string? Extenrene { get; set; }
        public string? Interne { get; set; }
        public string? Autre2 { get; set; }
        public string? DetailsEtResultats { get; set; }
        public DossierSociale dossierSociale { get; set; }
        public int DossierSocialeId { get; set; }
    }
}