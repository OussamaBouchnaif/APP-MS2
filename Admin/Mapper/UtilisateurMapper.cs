using Admin.Mapper.Contract;
using Admin.ViewModel;
using MS2Api.Model;

namespace Admin.Mapper
{
    public class UtilisateurMapper : IUtilisateurMapper
    {
        public Utilisateur MapToUtilisateur(UtilisateurVM utilisateurVM)
        {
            return new Utilisateur
            {
                Id = utilisateurVM.Id,
                Nom = utilisateurVM.Nom,
                Prenom = utilisateurVM.Prenom,
                Age = utilisateurVM.Age,
                Sexe = utilisateurVM.Sexe,
                Tele = utilisateurVM.Tele,
                Role = utilisateurVM.Role,
                Email = utilisateurVM.Email,
                MotDePasse = utilisateurVM.MotDePasse
            };
        }

        public UtilisateurVM MapToUtilisateurVM(Utilisateur utilisateur)
        {
            return new UtilisateurVM
            {
                Id = utilisateur.Id,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Age = utilisateur.Age,
                Sexe = utilisateur.Sexe,
                Tele = utilisateur.Tele,
                Role = utilisateur.Role,
                Email = utilisateur.Email,
                MotDePasse = utilisateur.MotDePasse
            };
        }

        public Utilisateur UpdateUtilisateur(UtilisateurVM utilisateurVM, Utilisateur utilisateur)
        {
            utilisateur.Id = utilisateurVM.Id;
            utilisateur.Nom = utilisateurVM.Nom;
            utilisateur.Prenom = utilisateurVM.Prenom;
            utilisateur.Age = utilisateurVM.Age;
            utilisateur.Sexe = utilisateurVM.Sexe;
            utilisateur.Tele = utilisateurVM.Tele;
            utilisateur.Role = utilisateurVM.Role;
            utilisateur.Email= utilisateurVM.Email;
            utilisateur.MotDePasse=utilisateurVM.MotDePasse;

            return utilisateur;
        }
    }
}