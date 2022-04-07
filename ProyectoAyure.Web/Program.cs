using Microsoft.EntityFrameworkCore;
using ProyectoAyure.Data.Contexto;
using Microsoft.Extensions.DependencyInjection;
using ProyectoAyure.Servicios.IServicios;
using ProyectoAyure.Servicios.Servicios;
using ProyectoAyure.Data.ViewModels;
using ProyectoAyure.Repositorios.IRepositorio;
using ProyectoAyure.Repositorios.Repositorio;

var perfilVM = new PerfilViewModel();
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AyureDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IPerfilServicio, PerfilServicio>();
builder.Services.AddScoped<IPerfilRepositorio, PerfilRepositorio>();
//builder.Services.AddTransient<IPerfilServicio, PerfilServicio>();
//builder.Services.AddSingleton<IPerfilServicio, PerfilServicio>();

builder.Services.AddControllersWithViews();

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

//app.MapGet("/Admin/RegistraPerfil/", (PerfilServicio perfilServicio) => perfilServicio.RegistraPerfil(perfilVM));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
