using Admin.Mapper.Contract;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS2Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void DeleteUtilisateur(int id)
        {
            var utilisateur = _utilisateurRepository.FindById(id);
            if (utilisateur == null)
            {
                throw new ArgumentException("Utilisateur non trouvé", nameof(id));
            }

            _utilisateurRepository.Delete(utilisateur);
            _utilisateurRepository.SaveChanges();
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

        public void UpdateUtilisateur(UtilisateurVM utilisateurVM)
        {
            if (utilisateurVM == null)
            {
                throw new ArgumentNullException(nameof(utilisateurVM));
            }

            var utilisateur = _utilisateurRepository.FindById(utilisateurVM.Id);
            if (utilisateur == null)
            {
                throw new ArgumentException("Utilisateur non trouvé", nameof(utilisateurVM.Id));
            }

            _utilisateurMapper.UpdateUtilisateur(utilisateurVM, utilisateur);
            _utilisateurRepository.Update(utilisateur);
            _utilisateurRepository.SaveChanges();
        }
    }
}
