using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProyectoAyure.Data.ViewModels;
using ProyectoAyure.Servicios.IServicios;
using System.Security.Claims;

namespace ProyectoAyure.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        #region Variables
        private IUsuarioServicio _usuarioServicio;
        private IUsuarioAccesoServicio _usuarioAccesoServicio;
        #endregion

        public AdminController(IUsuarioServicio usuarioServicio, IUsuarioAccesoServicio usuarioAccesoServicio)
        {
            _usuarioServicio = usuarioServicio;
            _usuarioAccesoServicio = usuarioAccesoServicio;
        }

        [HttpPost(Name = "Valida")]
        public string ValidarApi()
        {
            string Valida = "Funciona";
            return Valida;
        }

        [HttpPost(Name = "ValidaSesion")]
        public async Task<UsuarioAccesoViewModel> ValidaSesion(string Usuario, string Password)
        {
            UsuarioAccesoViewModel usuarioAcceso = new UsuarioAccesoViewModel();
            try
            {
                
                usuarioAcceso.NombreUsuario = Usuario;
                usuarioAcceso.Contraseña = Password;

                UsuarioAccesoViewModel usuarioSesion = _usuarioAccesoServicio.ValidaUsuarioSesion(usuarioAcceso);

                if (usuarioSesion == null)
                   return usuarioSesion;

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

                    //return RedirectToAction("Index", "Home");
                    //return true;
                    return usuarioSesion;
                }
                else
                {
                    //return RedirectToAction("Index", "Login");
                    return usuarioSesion;
                }
            }
            catch (Exception ex)
            {
                //return RedirectToAction("Index", "Login");
                //return false;
                return usuarioAcceso;
            }
        }
    }
}
