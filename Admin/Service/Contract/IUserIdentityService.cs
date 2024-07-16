using Admin.ViewModel;
using Microsoft.AspNetCore.Identity;
using MS2Api.Model;

namespace Admin.Service.Contract
{
    public interface IUserIdentityService
    {
        Task<(IdentityResult result, Utilisateur utilisateur)> CreateUserAsync(SigninViewModel model);

        Task<SignInResult> PasswordSignInAsync(LoginViewModel model);

        Task<IdentityResult> AddToRoleAsync(Utilisateur utilisateur, string role);

        Task SignOutAsync();
    }
}