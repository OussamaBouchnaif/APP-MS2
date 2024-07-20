using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MS2Api.Model;
using Newtonsoft.Json;

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
        var isLocked = _httpContextAccessor.HttpContext.Session.GetString("IsLocked");

        if (string.IsNullOrEmpty(userJson))
        {
            _httpContextAccessor.HttpContext.Session.SetString("ReturnUrl", context.HttpContext.Request.Path);
            context.Result = new RedirectToActionResult("Login", "Account", null);
            return;
        }

        if (!string.IsNullOrEmpty(isLocked))
        {
            _httpContextAccessor.HttpContext.Session.SetString("ReturnUrl", context.HttpContext.Request.Path);
            context.Result = new RedirectToActionResult("LockScreen", "Account", null);
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