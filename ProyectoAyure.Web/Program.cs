using Microsoft.EntityFrameworkCore;
using ProyectoAyure.Data.Contexto;
using Microsoft.Extensions.DependencyInjection;
using ProyectoAyure.Servicios.IServicios;
using ProyectoAyure.Servicios.Servicios;
using ProyectoAyure.Data.ViewModels;
using ProyectoAyure.Repositorios.IRepositorio;
using ProyectoAyure.Repositorios.Repositorio;
using ProyectoAyure.Data.Entidades;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.CookiePolicy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AyureDbContext>(options => {
    //Local Server
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //Azure Server
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection"));
});
//builder.Services.AddDefaultIdentity<UsuarioAcceso>().AddEntityFrameworkStores<AyureDbContext>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IPerfilServicio, PerfilServicio>();
builder.Services.AddScoped<IPerfilRepositorio, PerfilRepositorio>();
builder.Services.AddScoped<IUsuarioAccesoServicio, UsuarioAccesoServicio>();
builder.Services.AddScoped<IUsuarioAccesoRepositorio, UsuarioAccesoRepositorio>();
builder.Services.AddSession();

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//        builder =>
//        {
//            builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
//                                .AllowAnyHeader()
//                                .AllowAnyMethod();
//        });
//});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:7104/")
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index/";
        options.AccessDeniedPath = "/Home/Error/";
    });

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
//{
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//    options.SlidingExpiration = true;
//    options.AccessDeniedPath = "/Forbidden/";
//});

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy(new CookiePolicyOptions
    {
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always
    });

app.UseAuthentication();
app.UseAuthorization();

//app.MapGet("/Admin/RegistraPerfil/", (PerfilServicio perfilServicio) => perfilServicio.RegistraPerfil(perfilVM));

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/");

app.Run();
