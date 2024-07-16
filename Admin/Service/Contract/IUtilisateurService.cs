using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS2Api.Model;
using System.Linq.Expressions;

namespace Admin.Service.Contract
{
    public interface IUtilisateurService
    {
        IEnumerable<Utilisateur> GetAllUtilisateurs();
        Utilisateur GetUtilisateurById(int id);
        void AddUtilisateur(UtilisateurVM utilisateurVM);
        void UpdateUtilisateur(Utilisateur utilisateur );
        void DeleteUtilisateur(int id);
        void SaveChanges();
        List<SelectListItem> GetSexesList();
        List<SelectListItem> GetRolesList();
    }
}
