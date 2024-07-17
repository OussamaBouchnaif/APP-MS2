using Admin.ViewModel;
using MS2Api.Model;

namespace Admin.Mapper.Contract
{
    public interface IUtilisateurMapper
    {
        Utilisateur MapToUtilisateur(UtilisateurVM utilisateurVM);

        UtilisateurVM MapToUtilisateurVM(Utilisateur utilisateur);

        Utilisateur UpdateUtilisateur(UtilisateurVM utilisateurVM, Utilisateur utilisateur);
    }
}