using Admin.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS2Api.Model
{
    public class Benificier : Personne
    {
        public string TeleUrgent { get; set; }
        public string PaysOrigin { get; set; }

        public string Nationalite { get; set; }
        public string Address { get; set; }
        public string Ville { get; set; }

        public string TypeDetection { get; set; }
        public string codeUnique { get; set; }

        public DossierPersonnel? Dossier { get; set; }
        public IList<DossierMedical>? DossierMedicals { get; set; }
    }
}