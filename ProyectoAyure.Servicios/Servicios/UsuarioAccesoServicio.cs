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
    public class UsuarioAccesoServicio : IUsuarioAccesoServicio
    {
        private IUsuarioAccesoRepositorio _iUsuarioAccesoRepositorio;
        private IUsuarioServicio _iUsuarioServicio;

        public UsuarioAccesoServicio(IUsuarioAccesoRepositorio iUsuarioAccesoRepositorio, IUsuarioServicio iUsuarioServicio)
        {
            _iUsuarioAccesoRepositorio = iUsuarioAccesoRepositorio;
            _iUsuarioServicio = iUsuarioServicio;
        }
        public UsuarioAccesoViewModel ValidaUsuarioSesion(UsuarioAccesoViewModel usuarioSesion)
        {
            UsuarioAcceso usuarioAcceso = new UsuarioAcceso();
            try
            {
                usuarioAcceso.NombreUsuario = usuarioSesion.NombreUsuario;
                usuarioAcceso.Constraseña = usuarioSesion.Contraseña;

                usuarioAcceso = _iUsuarioAccesoRepositorio.ValidaInicioSesion(usuarioAcceso);

                if (usuarioAcceso != null)
                {
                    usuarioSesion.Id = usuarioAcceso.Id;
                    usuarioSesion.Identificador = usuarioAcceso.Identificador;

                    int idUsuario = (int)(usuarioAcceso.usuarioId == null ? 0 : usuarioAcceso.usuarioId);
                    usuarioSesion.usuarios = new UsuarioViewModel();
                    usuarioSesion.usuarios = _iUsuarioServicio.ObtieneUsuario(idUsuario);
                }

                return usuarioSesion;
            }
            catch (Exception ex)
            {
                return usuarioSesion;
            }
        }
    }
}
