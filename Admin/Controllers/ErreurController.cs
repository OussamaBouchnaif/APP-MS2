using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Route("Erreur/{statusCode}")]
    public class ErreurController : Controller
    {
        public IActionResult Index(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewData["Erreur"] = "Oups, page non trouvée";
                    return View("NotFoundPage");

                case 500:
                    ViewData["Erreur"] = "Erreur interne du serveur";
                    return View("ServerErrorPage");

                default:
                    ViewData["Erreur"] = "Une erreur s'est produite";
                    return View("Error");
            }
        }
    }
}