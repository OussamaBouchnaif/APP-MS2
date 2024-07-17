using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Admin.ViewModel
{
    public class UtilisateurVM : PersonneViewModel
    {
        [Required(ErrorMessage = "Le rôle est requis.")]
        [StringLength(50, ErrorMessage = "Le rôle ne peut pas dépasser 50 caractères.")]
        public string Role { get; set; }

        //[Display(Name = "Role")]
        //[Required(ErrorMessage = "Le rôle est requis.")]
        //public string RoleSelected { get; set; }

        //public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
    }
}