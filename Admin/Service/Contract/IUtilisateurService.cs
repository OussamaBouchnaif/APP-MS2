using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS2Api.Model;
using System.Collections.Generic;

namespace Admin.Service.Contract
{
    public interface IUtilisateurService
    {
        IEnumerable<Utilisateur> GetAllUtilisateurs();

        Utilisateur GetUtilisateurById(int id);

        void AddUtilisateur(UtilisateurVM utilisateurVM);

        void UpdateUtilisateur(UtilisateurVM  utilisateurVM , Utilisateur utilisateur);

        void DeleteUtilisateur(Utilisateur utilisateur);

        List<SelectListItem> GetSexesList();

        List<SelectListItem> GetRolesList();
    }
}
