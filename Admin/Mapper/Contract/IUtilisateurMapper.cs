using Admin.ViewModel;
using MS2Api.Model;

namespace Admin.Mapper.Contract
{
    public interface IUtilisateurMapper
    {
        Utilisateur MapToUtilisateur(UtilisateurVM utilisateurVM);
        UtilisateurVM MapToUtilisateurVM(Utilisateur utilisateur);
        void UpdateUtilisateur(UtilisateurVM utilisateurVM, Utilisateur utilisateur);
    }
}
