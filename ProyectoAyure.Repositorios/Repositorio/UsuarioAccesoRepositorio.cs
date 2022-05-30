using ProyectoAyure.Data.Contexto;
using ProyectoAyure.Data.Entidades;
using ProyectoAyure.Repositorios.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Repositorios.Repositorio
{
    public class UsuarioAccesoRepositorio :IUsuarioAccesoRepositorio
    {
        private readonly AyureDbContext _dbContext;

        public UsuarioAccesoRepositorio(AyureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UsuarioAcceso ObtieneUsuarioAcceso(UsuarioAcceso usuario)
        {
            UsuarioAcceso usuarioActivo = new UsuarioAcceso();
            try
            {
                usuarioActivo = _dbContext.UsuarioAcceso.Where(u => u.NombreUsuario == usuario.NombreUsuario).First();

                return usuarioActivo;
            }
            catch (Exception ex)
            {
                return usuarioActivo;
            }
        }

        public UsuarioAcceso ValidaInicioSesion(UsuarioAcceso usuarioSesion)
        {
            UsuarioAcceso usuarioActivo = new UsuarioAcceso();
            try
            {
                usuarioActivo = _dbContext.UsuarioAcceso.Where(u => u.NombreUsuario == usuarioSesion.NombreUsuario && u.Constraseña == usuarioSesion.Constraseña).First();

                return usuarioActivo;
            }
            catch (Exception ex)
            {
                return usuarioActivo;
            }
        }
    }
}
