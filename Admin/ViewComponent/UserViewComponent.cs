using Admin.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS2Api.Model;

public class UserViewComponent : ViewComponent
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserViewComponent(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public IViewComponentResult Invoke()
    {
        var user = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<Utilisateur>("User");
        if (user != null)
        {
            var userViewModel = new UtilisateurVM
            {
                Id = user.Id,
                Nom = user.Nom,
                Prenom = user.Prenom,
                Email = user.Email,
                Role = user.Role
            };
            return View(userViewModel);
        }
        return View(null);
    }
}