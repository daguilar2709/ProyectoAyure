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
        public async Task<IActionResult> ValidaUsuario(string Usuario, string Password)
        {
            UsuarioAccesoViewModel usuarioAcceso = new UsuarioAccesoViewModel();
            usuarioAcceso.NombreUsuario = Usuario;
            usuarioAcceso.Contraseña = Password;

            UsuarioAccesoViewModel usuarioSesion = _usuarioAccesoServicio.ValidaUsuarioSesion(usuarioAcceso);
            if (usuarioSesion != null)
                if (usuarioSesion.usuarios != null) {
                    usuarioSesion.usuarios = _usuarioServicio.ObtieneUsuario(usuarioSesion.usuarios.Id);
                } else {
                    usuarioSesion.usuarios = new UsuarioViewModel();
                    usuarioSesion.usuarios.Id = 0;
                }  
            else
                return RedirectToAction("Index", "Login");

            if (usuarioSesion.usuarios.Id != 0)
            {
                //var claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name, usuarioSesion.NombreUsuario),
                //    new Claim(ClaimTypes.Role, usuarioSesion.usuarios.nombrePerfil)
                //};

                //var claimsIdentity = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                //var authProperties = new AuthenticationProperties
                //{
                //    ExpiresUtc = DateTime.UtcNow.AddMinutes(25),
                //    IssuedUtc = DateTime.UtcNow,
                //    IsPersistent = true
                //};

                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);

                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                Claim claimUserName = new Claim(ClaimTypes.Name, usuarioSesion.NombreUsuario);
                Claim claimRole = new Claim(ClaimTypes.Role, usuarioSesion.usuarios.nombrePerfil);
                Claim claimIdUsuario = new Claim("IdUsuario", usuarioSesion.usuarios.Id.ToString());
                Claim claimEmail = new Claim("EmailUsuario", usuarioSesion.usuarios.Email == null ? "" : usuarioSesion.usuarios.Email);

                identity.AddClaim(claimUserName);
                identity.AddClaim(claimRole);
                identity.AddClaim(claimIdUsuario);
                identity.AddClaim(claimEmail);

                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(45),
                });

                //return RedirectToAction("Index", "Home");
                return Ok(usuarioSesion);
            }
            else
            {
                return RedirectToAction("Index", "Login");
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
