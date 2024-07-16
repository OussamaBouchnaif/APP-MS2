using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Identity;
using MS2Api.Model;

namespace Admin.Service
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly UserManager<Personne> userManager;
        private readonly SignInManager<Personne> signInManager;

        public UserIdentityService(UserManager<Personne> userManager, SignInManager<Personne> signInManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.signInManager = signInManager;
        }

        public async Task<(IdentityResult result, Utilisateur utilisateur)> CreateUserAsync(SigninViewModel model)
        {
            var user = new Utilisateur
            {
                Email = model.Email,
                UserName = model.Email,
                Nom = model.Nom,
                Prenom = model.Prenom,
                Sexe = model.Sexe,
                Age = model.Age,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);
            return (result, result.Succeeded ? user : null);
        }

        public async Task<IdentityResult> AddToRoleAsync(Utilisateur utilisateur, string role)
        {
            if (utilisateur == null)
            {
                throw new ArgumentNullException(nameof(utilisateur), "L'utilisateur ne peut pas être null.");
            }

            if (string.IsNullOrEmpty(role))
            {
                throw new ArgumentException("Le rôle ne peut pas être null ou vide.", nameof(role));
            }

            return await this.userManager.AddToRoleAsync(utilisateur, role);
        }

        public async Task<SignInResult> PasswordSignInAsync(LoginViewModel model)
        {
            return await this.signInManager.PasswordSignInAsync(
                userName: model.Email,
                password: model.Password,
                isPersistent: true,
                lockoutOnFailure: false
            );
        }

        public async Task SignOutAsync()
        {
            await this.signInManager.SignOutAsync();
        }
    }
}