using System.ComponentModel.DataAnnotations;

namespace MS2Api.Model
{
    public class ParcoursMigratoire
    {
        [Key]
        public int Id { get; set; }

        public string? MotifDepart { get; set; }
        public string? AutreMotif { get; set; }
        public DateTime? AnneeEntree { get; set; }
        public string? Voie { get; set; }
        public string? VilleEntree { get; set; }
        public int? Duree { get; set; }
        public int? DureeEntree { get; set; }
        public bool? NouvelleArrivante { get; set; }

        public DossierPersonnel Dossier { get; set; }
        public int? DossierPersonnelId { get; set; }
    }
}