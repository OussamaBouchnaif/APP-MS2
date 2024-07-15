using Admin.Mapper.Contract;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS2Api.Model;
using System.Linq.Expressions;

namespace Admin.Service
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IRepository<Utilisateur> _UtilisateurRepository;
        private readonly IUtilisateurMapper _UtilisateurMapper;
        public UtilisateurService(IRepository<Utilisateur> UtilisateurRepository, IUtilisateurMapper UtilisateurMapper)
        {
            _UtilisateurRepository = UtilisateurRepository;
            _UtilisateurMapper=UtilisateurMapper;

        }

        public void AddUtilisateur(UtilisateurVM utilisateurVM)
        {
            if (utilisateurVM == null)
            {
                throw new ArgumentNullException(nameof(utilisateurVM));
            }
            Utilisateur utilisateur= _UtilisateurMapper.MapToUtilisateur(utilisateurVM);
            _UtilisateurRepository.Insert(utilisateur);
            _UtilisateurRepository.SaveChanges();
        }

        public void DeleteUtilisateur(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Utilisateur> GetAllUtilisateurs()
        {
            return _UtilisateurRepository.GetAll().ToList();
        }

        public Utilisateur GetUtilisateurById(int id)
        {
            return _UtilisateurRepository.FindById(id);
        }

        public void SaveChanges()
        {
            _UtilisateurRepository.SaveChanges();   
        }

        public void UpdateUtilisateur(Utilisateur utilisateur)
        {
            if (utilisateur == null)
            {
                throw new ArgumentNullException(nameof(utilisateur));
            }
            _UtilisateurRepository.Update(utilisateur);
            SaveChanges();

        }

        List<SelectListItem> IUtilisateurService.GetSexesList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Homme", Text = "Homme" },
                new SelectListItem { Value = "Femme", Text = "Femme" }
            };
        }

        List<SelectListItem> IUtilisateurService.GetRolesList()
        {
            return new List<SelectListItem>
            {
                 new SelectListItem { Value = "Admin", Text = "Admin" },
                new SelectListItem { Value = "Agent", Text = "Agent" }
            };
        }
    }
}
