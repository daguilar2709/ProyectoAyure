using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProyectoAyure.Data.Contexto;
using ProyectoAyure.Repositorios.IRepositorio;
using ProyectoAyure.Repositorios.Repositorio;
using ProyectoAyure.Servicios.IServicios;
using ProyectoAyure.Servicios.Servicios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AyureDbContext>(options => {
    //Local Server
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //Azure Server
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection"));
});

// Add services to the container.
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IPerfilServicio, PerfilServicio>();
builder.Services.AddScoped<IPerfilRepositorio, PerfilRepositorio>();
builder.Services.AddScoped<IUsuarioAccesoServicio, UsuarioAccesoServicio>();
builder.Services.AddScoped<IUsuarioAccesoRepositorio, UsuarioAccesoRepositorio>();

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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index/";
        options.AccessDeniedPath = "/Home/Error/";
    });

var app = builder.Build();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
