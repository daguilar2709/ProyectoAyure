using ProyectoAyure.Data.Entidades;
using ProyectoAyure.Data.ViewModels;
using ProyectoAyure.Repositorios.IRepositorio;
using ProyectoAyure.Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Servicios.Servicios
{
    public class UsuarioServicio:IUsuarioServicio
    {
        private IUsuarioRepositorio _iUsuarioRepositorio;

        public UsuarioServicio(IUsuarioRepositorio iUsuarioRepositorio)
        {
            _iUsuarioRepositorio = iUsuarioRepositorio;
        }

        public UsuarioViewModel ObtieneUsuario(int idUsuario)
        {
            UsuarioViewModel usuarioVM = new UsuarioViewModel();
            try
            {
                Usuarios usuario = _iUsuarioRepositorio.ObtieneUsuario(idUsuario);

                usuarioVM.Id = usuario.Id;
                usuarioVM.Nombre = usuario.Nombre;
                usuarioVM.ApellidoPaterno = usuario.ApellidoPaterno;
                usuarioVM.ApellidoMaterno = usuario.ApellidoMaterno;
                usuarioVM.Direccion = usuario.Direccion;
                usuarioVM.CodigoPostal = usuario.CodigoPostal;
                usuarioVM.Telefono1 = usuario.Telefono1;
                usuarioVM.Telefono2 = usuario.Telefono2 == null ? "" : usuario.Telefono2;
                usuarioVM.FechaCreacion = usuario.FechaCreacion;
                usuarioVM.FechaModificacion = usuario.FechaModificacion;
                usuarioVM.perfilId = usuario.perfiles == null ? 0 : usuario.perfiles.Id;
                usuarioVM.nombrePerfil = usuario.perfiles == null ? "" : usuario.perfiles.NombrePerfil;
                usuarioVM.Activo = usuario.Activo;

                return usuarioVM;
            }
            catch (Exception ex)
            {
                return usuarioVM;
            }
        }

        public List<UsuarioViewModel> ObtieneUsuarios()
        {
            List<UsuarioViewModel> lstusuarioVM = new List<UsuarioViewModel>();
            try
            {
                List<Usuarios> lstUsuario = _iUsuarioRepositorio.ObtieneUsuarios();
                foreach (var usuario in lstUsuario)
                {
                    lstusuarioVM.Add(new UsuarioViewModel() {
                        Id = usuario.Id,
                        Nombre = usuario.Nombre,
                        ApellidoPaterno = usuario.ApellidoPaterno,
                        ApellidoMaterno = usuario.ApellidoMaterno,
                        Direccion = usuario.Direccion,
                        CodigoPostal = usuario.CodigoPostal,
                        Telefono1 = usuario.Telefono1,
                        Telefono2 = usuario.Telefono2 == null ? "" : usuario.Telefono2,
                        FechaCreacion = usuario.FechaCreacion,
                        FechaModificacion = usuario.FechaModificacion,
                        perfilId = usuario.perfiles == null ? 0 : usuario.perfiles.Id,
                        nombrePerfil = usuario.perfiles == null ? "" : usuario.perfiles.NombrePerfil,
                        Activo = usuario.Activo
                    });
                }

                return lstusuarioVM;
            }
            catch (Exception ex)
            {
                return lstusuarioVM;
            }
        }

        public bool RegistraUsuario(UsuarioViewModel usuarioVM)
        {
            Usuarios usuario = new Usuarios();

            try
            {
                usuario.Nombre = usuarioVM.Nombre;
                usuario.ApellidoPaterno = usuarioVM.ApellidoPaterno;
                usuario.ApellidoMaterno = usuarioVM.ApellidoMaterno;
                usuario.Direccion = usuarioVM.Direccion;
                usuario.CodigoPostal = usuarioVM.CodigoPostal;
                usuario.Telefono1 = usuarioVM.Telefono1;
                usuario.Telefono2 = usuarioVM.Telefono2;
                usuario.FechaCreacion = usuarioVM.FechaCreacion;
                usuario.FechaModificacion = usuarioVM.FechaModificacion;
                usuario.Activo = usuarioVM.Activo;
                int perfilId = usuarioVM.perfilId;

                usuario = _iUsuarioRepositorio.RegistraUsuario(usuario, perfilId);

                usuario.usuarioAcceso = CreaAcceso(usuario);
                usuario.usuarioAccesoId = usuario.usuarioAcceso.Id;

                usuario = _iUsuarioRepositorio.ActualizaUsuario(usuario);

                if (usuario == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        } 

        private UsuarioAcceso CreaAcceso(Usuarios usuarioVM)
        {
            UsuarioAcceso usuarioAcceso = new UsuarioAcceso();

            var nombres = usuarioVM.Nombre.Split(' ');
            usuarioAcceso.NombreUsuario = nombres[0].ToLower()+usuarioVM.ApellidoPaterno;
            usuarioAcceso.Constraseña = "prueba123";
            usuarioAcceso.Identificador = Guid.NewGuid();
            usuarioAcceso.FechaCreacion = DateTime.Now;
            usuarioAcceso.FechaModificacion = DateTime.Now;
            usuarioAcceso.Activo = true;

            usuarioAcceso = _iUsuarioRepositorio.RegistraAcceso(usuarioAcceso);

            return usuarioAcceso;
        }

        public bool EditaUsuario (UsuarioViewModel usuarioVM)
        {
            try
            {
                Usuarios usuario = new Usuarios();
                usuario.Id = usuarioVM.Id;
                usuario.Nombre = usuarioVM.Nombre;
                usuario.ApellidoPaterno = usuarioVM.ApellidoPaterno;
                usuario.ApellidoMaterno = usuarioVM.ApellidoMaterno;
                usuario.Direccion = usuarioVM.Direccion;
                usuario.perfilId = usuarioVM.perfilId;
                usuario.CodigoPostal = usuarioVM.CodigoPostal;
                usuario.Telefono1 = usuarioVM.Telefono1;
                usuario.Telefono2 = usuarioVM.Telefono2;
                usuario.FechaCreacion = usuarioVM.FechaCreacion;
                usuario.FechaModificacion = usuarioVM.FechaModificacion;
                usuario.Activo = usuarioVM.Activo;

                var usuarioActualizado = _iUsuarioRepositorio.ActualizaUsuario(usuario);

                if (usuarioActualizado != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminaUsuario(int idUsuario)
        {
            try
            {
                _iUsuarioRepositorio.EliminaUsuario(idUsuario);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
