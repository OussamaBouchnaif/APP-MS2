using Admin.Extensions;
using Admin.Repository;
using Admin.Service.Contract;
using Microsoft.EntityFrameworkCore;
using MS2Api.Data;
using Admin.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Configuration.AddCustomConfiguration(builder.Environment);

builder.Services.AddDbContext<MyContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDb"))
    );

// Ajouter le repository générique
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Ajouter le service des bénéficiaires
builder.Services.AddScoped<IBeneficiaryService, Admin.Service.BenificierService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Benificier}/{action=Index}/{id?}");

app.Run();
