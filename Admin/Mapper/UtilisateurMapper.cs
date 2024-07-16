using Admin.Mapper.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MS2Api.Model;
using System.Data;

namespace Admin.Mapper
{
    public class UtilisateurMapper : IUtilisateurMapper
    {
        public Utilisateur MapToUtilisateur(UtilisateurVM utilisateurVM)
        {
            if (utilisateurVM == null)
            {
                return null;
            }
            return new Utilisateur
            {
                Id = utilisateurVM.Id,
                Nom = utilisateurVM.Nom,
                Prenom = utilisateurVM.Prenom,
                Age = utilisateurVM.Age,
                Sexe = utilisateurVM.Sexe,
                PhoneNumber = utilisateurVM.Tele,
                //Role = utilisateurVM.Role,
            };
        }

        public Utilisateur UpdateUtilisateru(UtilisateurVM utilisateurVM, Utilisateur utilisateur)
        {
            if (utilisateurVM == null || utilisateur == null)
            {
                return null;
            }
            utilisateur.Id = utilisateurVM.Id;
            utilisateur.Nom = utilisateurVM.Nom;
            utilisateur.Prenom = utilisateurVM.Prenom;
            utilisateur.Age = utilisateurVM.Age;
            utilisateur.Sexe = utilisateurVM.Sexe;
            utilisateur.PhoneNumber = utilisateurVM.Tele;
            //utilisateur.Role = utilisateurVM.Role;

            return utilisateur;
        }
    }
}