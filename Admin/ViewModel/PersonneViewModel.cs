using System.ComponentModel.DataAnnotations;

namespace Admin.ViewModel
{
    public class PersonneViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(100, ErrorMessage = "Le prénom ne peut pas dépasser 100 caractères.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "L'âge est requis.")]
        [Range(0, 120, ErrorMessage = "L'âge doit être compris entre 0 et 120 ans.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Le sexe est requis.")]
        [RegularExpression("^(Homme|Femme)$", ErrorMessage = "Le sexe doit être soit 'Homme' soit 'Femme'.")]
        public string Sexe { get; set; }

        [Required(ErrorMessage = "Le téléphone est requis.")]
        [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide.")]
        [StringLength(15, ErrorMessage = "Le numéro de téléphone ne peut pas dépasser 15 caractères.")]
        public string Tele { get; set; }
    }

}
