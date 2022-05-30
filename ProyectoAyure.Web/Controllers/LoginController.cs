using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoAyure.Data.ViewModels;
using ProyectoAyure.Servicios.IServicios;
using System.Security.Claims;

namespace ProyectoAyure.Web.Controllers
{
    public class LoginController : Controller
    {
        #region Variables
        private IUsuarioServicio _usuarioServicio;
        private IUsuarioAccesoServicio _usuarioAccesoServicio;
        #endregion

        #region Constructor
        public LoginController(IUsuarioServicio usuarioServicio, IUsuarioAccesoServicio usuarioAccesoServicio)
        {
            _usuarioServicio = usuarioServicio;
            _usuarioAccesoServicio = usuarioAccesoServicio;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> ValidaUsuario(UsuarioAccesoViewModel usuarioAcceso)
        {
            UsuarioAccesoViewModel usuarioSesion = _usuarioAccesoServicio.ValidaUsuarioSesion(usuarioAcceso);

            usuarioSesion.usuarios = _usuarioServicio.ObtieneUsuario(usuarioSesion.usuarios.Id);

            if (usuarioSesion.Id != 0)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuarioSesion.NombreUsuario),
                    new Claim(ClaimTypes.Role, usuarioSesion.usuarios.nombrePerfil)
                };

                var claimsIdentity = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(25),
                    IssuedUtc = DateTime.UtcNow,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public async Task<IActionResult> Salir()
        {
            await CerrarSesion(HttpContext);
            return RedirectToAction("Index", "Login");
        }

        public async Task CerrarSesion(HttpContext ctx)
        {
            await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);            
        }
    }
}
