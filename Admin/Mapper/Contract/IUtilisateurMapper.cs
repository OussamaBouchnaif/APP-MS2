using Admin.ViewModel;
using MS2Api.Model;
namespace Admin.Mapper.Contract

{
    public interface IUtilisateurMapper
    {
        Utilisateur MapToUtilisateur(UtilisateurVM utilisateurVM);
        Utilisateur UpdateUtilisateru(UtilisateurVM utilisateurVM,Utilisateur utilisateur);

    }
}
