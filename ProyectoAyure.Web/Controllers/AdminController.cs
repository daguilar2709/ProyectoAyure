using Microsoft.AspNetCore.Mvc;
using ProyectoAyure.Data.ViewModels;
using ProyectoAyure.Servicios.IServicios;

namespace ProyectoAyure.Web.Controllers
{
    public class AdminController : Controller
    {
        #region Variables
        private IUsuarioServicio _usuarioServicio;
        private IPerfilServicio _perfilServicio;
        #endregion

        #region Constructor
        public AdminController(IUsuarioServicio usuarioServicio, IPerfilServicio perfilServicio)
        {
            _usuarioServicio = usuarioServicio;
            _perfilServicio = perfilServicio;
        }
        #endregion

        #region Vistas
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            List<UsuarioViewModel> lstUsuarioVM = _usuarioServicio.ObtieneUsuarios();
            return View(lstUsuarioVM);
        }

        public IActionResult Perfiles()
        {
            List<PerfilViewModel> lstPerfilesVM = _perfilServicio.ObtienePerfiles();
            return View(lstPerfilesVM);
        }
        #endregion

        #region Acciones Vista Usuarios
        public IActionResult CreaUsuario(UsuarioViewModel usuarioVM)
        {
            usuarioVM.FechaCreacion = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            usuarioVM.FechaModificacion = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            usuarioVM.Activo = true;

             var UsuarioCreado = _usuarioServicio.RegistraUsuario(usuarioVM);

            return Ok(Json(true));
        }

        public IActionResult ObtieneUsuario(int idUsuario)
        {
            var usuario = _usuarioServicio.ObtieneUsuario(idUsuario);

            return Ok(Json(usuario));
        }

        [HttpPost("/Admin/CargaPerfiles/")]
        public IActionResult CargaPerfiles()
        {
            List<PerfilViewModel> lstPerfilesVM = _perfilServicio.ObtienePerfiles();
            return Ok(Json(lstPerfilesVM));
        }

        [HttpPost("/Admin/EditaUsuario/")]
        public IActionResult EditaUsuario(UsuarioViewModel usuarioVM)
        {
            try
            {
                var usuarioActualizado = _usuarioServicio.EditaUsuario(usuarioVM);
                if (usuarioActualizado)
                {
                    return Ok(Json(true));
                }
                else
                {
                    return Ok(Json(false));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("/Admin/EliminaUsuario/")]
        public IActionResult EliminaUsuario(int idUsuario)
        {
            try
            {
                _usuarioServicio.EliminaUsuario(idUsuario);
                return Ok(Json(true));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion 

        #region Acciones Vista Perfill
        [HttpPost("/Admin/RegistraPerfil/")]
        public IActionResult RegistraPerfil(PerfilViewModel perfilVM)
        {
            try
            {
                var perfilRegistrado = _perfilServicio.RegistraPerfil(perfilVM);
                if (perfilRegistrado)
                {
                    return Ok(Json(true));
                }
                else
                {
                    return Ok(Json(false));
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("/Admin/EditaPerfil/")]
        public IActionResult EditaPerfil(PerfilViewModel perfilVM)
        {
            try
            {
                var perfilActualizado = _perfilServicio.EditaPerfil(perfilVM);
                if (perfilActualizado)
                {
                    return Ok(Json(true));
                }
                else
                {
                    return Ok(Json(false));
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("/Admin/EliminaPerfil/")]
        public IActionResult EliminaPerfil(int idPerfil)
        {
            try
            {
                _perfilServicio.EliminaPerfil(idPerfil);
                return Ok(Json(true));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
