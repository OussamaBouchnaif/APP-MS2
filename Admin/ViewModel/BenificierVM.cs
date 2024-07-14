using System.ComponentModel.DataAnnotations;

namespace Admin.ViewModel
{
    public class BenificierVM
    {
        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(100, ErrorMessage = "Le prénom ne peut pas dépasser 100 caractères.")]
        public string Prenom { get; set; }

        [Range(0, 120, ErrorMessage = "L'âge doit être compris entre 0 et 120.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Le sexe est requis.")]
        [StringLength(10, ErrorMessage = "Le sexe ne peut pas dépasser 10 caractères.")]
        public string Sexe { get; set; }

        [Required(ErrorMessage = "Le téléphone est requis.")]
        [Phone(ErrorMessage = "Le format du téléphone n'est pas valide.")]
        public string Tele { get; set; }

        [Required(ErrorMessage = "Le téléphone d'urgence est requis.")]
        [Phone(ErrorMessage = "Le format du téléphone d'urgence n'est pas valide.")]
        public string TeleUrgent { get; set; }

        [Required(ErrorMessage = "Le pays d'origine est requis.")]
        [StringLength(100, ErrorMessage = "Le pays d'origine ne peut pas dépasser 100 caractères.")]
        public string PaysOrigin { get; set; }

        [Required(ErrorMessage = "La nationalité est requise.")]
        [StringLength(100, ErrorMessage = "La nationalité ne peut pas dépasser 100 caractères.")]
        public string Nationalite { get; set; }

        [Required(ErrorMessage = "L'adresse est requise.")]
        [StringLength(200, ErrorMessage = "L'adresse ne peut pas dépasser 200 caractères.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "La ville est requise.")]
        [StringLength(100, ErrorMessage = "La ville ne peut pas dépasser 100 caractères.")]
        public string Ville { get; set; }

        [Required(ErrorMessage = "Le type de détection est requis.")]
        [StringLength(100, ErrorMessage = "Le type de détection ne peut pas dépasser 100 caractères.")]
        public string TypeDetection { get; set; }

        [Required(ErrorMessage = "Le code unique est requis.")]
        [StringLength(50, ErrorMessage = "Le code unique ne peut pas dépasser 50 caractères.")]
        public string codeUnique { get; set; }
    }
}
