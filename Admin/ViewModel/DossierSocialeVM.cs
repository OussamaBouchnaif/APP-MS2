using Admin.Models;
using MS2Api.Model;
using System.ComponentModel.DataAnnotations;

namespace Admin.ViewModel
{
    public class DossierSocialeVM
    {
        public int Id { get; set; }

        public bool DemandeInformation { get; set; }
        public bool PriseEnChargeMedical { get; set; }
        public bool Hebergement { get; set; }
        public bool ApuiAdminstrative { get; set; }
        public bool ActeDeNaissance { get; set; }
        public bool DemandeAsile { get; set; }
        public bool DemandeRetourVolontaire { get; set; }
        public string? autre1 { get; set; }
        public string? kitsAlimentaionEtHyfiene { get; set; }
        public bool ApuiSocialProfessionnel { get; set; }
        public bool formation { get; set; }
        public bool emploi { get; set; }
        public string? autre2 { get; set; }
        public bool DelivranceInformation { get; set; }
        public bool AnamneseEtDiscusionPlanDesuite { get; set; }
        public DateTime? DateEntreeHebergementUrgence { get; set; }
        public bool DistributiondeKit { get; set; }
        public string? AccompagnementPhysique { get; set; }
        public string? Orientation { get; set; }
        public bool ReferencementExterne { get; set; }
        public bool ReferencementIntern { get; set; }
        public string? Extenrene { get; set; }
        public string? Interne { get; set; }
        public string? Autre3 { get; set; }
        public string? DetailsEtResultats { get; set; }

        public int BenificierId { get; set; }
        public Benificier? Benificier { get; set; }
    }
}