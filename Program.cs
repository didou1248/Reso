using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using RestoManager_SadkaouiMouhamed.Models.RestosModel;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services � l'application
builder.Services.AddControllersWithViews();

// Ajouter le contexte EF Core avec la cha�ne de connexion correcte
builder.Services.AddDbContext<RestosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestosConnection"))
);

var app = builder.Build();

// Configurer le pipeline de requ�tes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// D�finir la route par d�faut pour que l'action Index de ProprietairesController soit l'action de d�marrage
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Proprietaires}/{action=Index}/{id?}");

// Lancer l'application
app.Run();
