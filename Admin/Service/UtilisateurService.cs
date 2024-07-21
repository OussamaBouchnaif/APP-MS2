using Admin.Mapper.Contract;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS2Api.Model;

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

        public void UpdateUtilisateur(UtilisateurVM utilisateurVM, Utilisateur existingUtilisateur)
        {
            if (utilisateurVM == null || existingUtilisateur == null)
            {
                throw new ArgumentNullException(nameof(utilisateurVM));
            }

            _utilisateurMapper.UpdateUtilisateur(utilisateurVM, existingUtilisateur);

            if (!string.IsNullOrEmpty(utilisateurVM.MotDePasse))
            {
                existingUtilisateur.MotDePasse = _passwordHasher.HashPassword(existingUtilisateur, utilisateurVM.MotDePasse);
            }

            _utilisateurRepository.Update(existingUtilisateur);
            _utilisateurRepository.SaveChanges();
        }

        public void DeleteUtilisateur(Utilisateur utilisateur)
        {
            if (utilisateur == null)
            {
                throw new ArgumentException(nameof(utilisateur));
            }
            _utilisateurRepository.Delete(utilisateur);
            _utilisateurRepository.SaveChanges();
        }

        public UtilisateurVM GetProfile(int utilisateurId)
        {
            var utilisateur = _utilisateurRepository.FindById(utilisateurId);

            if (utilisateur == null)
            {
                // Log the ID to help with debugging
                Console.WriteLine($"Utilisateur with ID {utilisateurId} not found.");
                throw new ArgumentException("Utilisateur non trouvé", nameof(utilisateurId));
            }

            return _utilisateurMapper.MapToUtilisateurVM(utilisateur);
        }
    }
}