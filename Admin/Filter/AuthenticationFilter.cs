using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using MS2Api.Model;

public class AuthenticationFilter : IAsyncActionFilter
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthenticationFilter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var userJson = _httpContextAccessor.HttpContext.Session.GetString("User");
        if (string.IsNullOrEmpty(userJson))
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
            return;
        }

        var user = JsonConvert.DeserializeObject<Utilisateur>(userJson);
        if (user == null)
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
            return;
        }

        await next();
    }
}