using Admin.Mapper.Contract;
using Admin.Models;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Identity;
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
        private readonly IPasswordHasher<Utilisateur> _passwordHasher;

        public UtilisateurService(IRepository<Utilisateur> utilisateurRepository, IUtilisateurMapper utilisateurMapper, IPasswordHasher<Utilisateur> passwordHasher)
        {
            _utilisateurRepository = utilisateurRepository;
            _utilisateurMapper = utilisateurMapper;
            _passwordHasher = passwordHasher;
        }

        public void AddUtilisateur(UtilisateurVM utilisateurVM)
        {
            if (utilisateurVM == null)
            {
                throw new ArgumentNullException(nameof(utilisateurVM));
            }

            var utilisateur = _utilisateurMapper.MapToUtilisateur(utilisateurVM);
            utilisateur.MotDePasse = _passwordHasher.HashPassword(utilisateur, utilisateurVM.MotDePasse);
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

        public void UpdateUtilisateur(UtilisateurVM utilisateurVM, Utilisateur existingutilisateur)
        {
            if (utilisateurVM == null || existingutilisateur == null)
            {
                throw new ArgumentNullException(nameof(utilisateurVM));
            }

            _utilisateurMapper.UpdateUtilisateur(utilisateurVM, existingutilisateur);


            if (!string.IsNullOrEmpty(utilisateurVM.MotDePasse))
            {
                existingutilisateur.MotDePasse = _passwordHasher.HashPassword(existingutilisateur, utilisateurVM.MotDePasse);
            }
        }

            public void DeleteUtilisateur(Utilisateur utilisateur)
            {
                throw new NotImplementedException();
            }
        }
}

