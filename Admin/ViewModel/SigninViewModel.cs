using Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Admin.ViewModel
{
    public class SigninViewModel
    {
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est requis")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "L'âge est requis")]
        [Range(18, 90, ErrorMessage = "L'âge doit être compris entre 18 et 90 ans")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Le numéro du téléphone est requis")]
        [RegularExpression(@"^(06|07)\d{8}$", ErrorMessage = "Le numéro de téléphone doit commencer par 06 ou 07 et contenir 10 chiffres")]
        public string Tele { get; set; }

        [Required(ErrorMessage = "Le sexe est requis")]
        [RegularExpression("^(Homme|Femme|Autre)$", ErrorMessage = "Le sexe doit être Homme, Femme ou Autre")]
        public string Sexe { get; set; }

        [Display(Name = "Role")]
        public string RoleSelected { get; set; }

        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();

        [Required(ErrorMessage = "L'adresse e-mail est requise")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit comporter entre 6 et 100 caractères")]
        public string Password { get; set; }
    }
}