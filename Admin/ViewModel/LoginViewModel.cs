﻿using System.ComponentModel.DataAnnotations;

namespace Admin.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "L'adresse e-mail est requise")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}