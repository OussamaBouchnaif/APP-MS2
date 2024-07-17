using Admin.Mapper.Contract;
using Admin.Models;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS2Api.Model;

namespace Admin.Service
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IRepository<Utilisateur> _utilisateurRepository;
        private readonly IUtilisateurMapper _utilisateurMapper;

        public UtilisateurService(IRepository<Utilisateur> utilisateurRepository, IUtilisateurMapper utilisateurMapper)
        {
            _utilisateurRepository = utilisateurRepository;
            _utilisateurMapper = utilisateurMapper;
        }

        public void AddUtilisateur(UtilisateurVM utilisateurVM)
        {
            if (utilisateurVM == null)
            {
                throw new ArgumentNullException(nameof(utilisateurVM));
            }

            var utilisateur = _utilisateurMapper.MapToUtilisateur(utilisateurVM);
            _utilisateurRepository.Insert(utilisateur);
            _utilisateurRepository.SaveChanges();
        }

        public void DeleteUtilisateur(Utilisateur utilisateur)
        {
            if (utilisateur == null)
            {
                throw new ArgumentNullException(nameof(utilisateur));
            }

            _utilisateurRepository.Delete(utilisateur);
            SaveChanges();
        }

        public IEnumerable<Utilisateur> GetAllUtilisateurs()
        {
            return _utilisateurRepository.GetAll().ToList();
        }

        public Utilisateur GetUtilisateurById(int id)
        {
            return _utilisateurRepository.FindById(id);
        }

        public List<SelectListItem> GetSexesList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Homme", Text = "Homme" },
                new SelectListItem { Value = "Femme", Text = "Femme" }
            };
        }

        public List<SelectListItem> GetRolesList()
        {
            return new List<SelectListItem>
            {
                 new SelectListItem { Value = "Admin", Text = "Admin" },
                 new SelectListItem { Value = "Agent", Text = "Agent" }
            };
        }

        public void UpdateUtilisateur(UtilisateurVM utilisateurVM, Utilisateur exestingUtilisateur)
        {
            if (utilisateurVM == null || exestingUtilisateur == null)
            {
                throw new ArgumentNullException(nameof(utilisateurVM));
            }

            _utilisateurMapper.UpdateUtilisateur(utilisateurVM, exestingUtilisateur);
            _utilisateurRepository.Update(exestingUtilisateur);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _utilisateurRepository.SaveChanges();
        }
    }
}