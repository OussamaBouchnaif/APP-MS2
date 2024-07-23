using Admin.Extensions;
using Admin.Models;
using MS2Api.Data;
using MS2Api.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.AddCustomConfiguration(builder.Environment);

builder.AddGestionCommandesContext();
builder.Services.AddCustomServices();

//// configuration de Identity
//builder.Services.ConfigureIdentity();

//builder.Services.ConfigureApplicationCookie(option => option.LoginPath = "/Account/Login");

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithRedirects("/Erreur/{0}");
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Ajoutez cette ligne pour l'authentification
app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Benificier}/{action=Index}");

// Créer les rôles
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    await RoleInitializer.CreateRoles(services);
//}

app.Run();