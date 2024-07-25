using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class Participation
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Thematique { get; set; }

        public DossierSociale dossierSociale { get; set; }
        public int DossierSocialeId { get; set; }
    }
}