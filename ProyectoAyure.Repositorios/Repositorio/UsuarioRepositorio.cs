using ProyectoAyure.Data.Contexto;
using ProyectoAyure.Data.Entidades;
using ProyectoAyure.Repositorios.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ProyectoAyure.Repositorios.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AyureDbContext _dbContext;

        public UsuarioRepositorio(AyureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Usuarios> ObtieneUsuarios()
        {
            List<Usuarios> lstUsuarios = new List<Usuarios>();

            try
            {
                lstUsuarios = _dbContext.Usuarios.ToList();
                return lstUsuarios;
            }
            catch (Exception ex)
            {
                return lstUsuarios;
            }
        }

        public Usuarios ObtieneUsuario(int idUsuario)
        {
            Usuarios usuarios = new Usuarios();

            try
            {
                usuarios = _dbContext.Usuarios.Where(u => u.Id == idUsuario).First();
                return usuarios;
            }
            catch (Exception ex)
            {
                return usuarios;
            }
        }

        public Usuarios RegistraUsuario(Usuarios usuario, int PerfilId)
        {
            try
            {
                _dbContext.Usuarios.Add(usuario);
                _dbContext.SaveChanges();
                var usuarioRegistrado = _dbContext.Usuarios.Where(u => u.Nombre.ToLower() == usuario.Nombre.ToLower()).First();
                usuarioRegistrado.perfiles = _dbContext.Perfiles.Where(p => p.Id == PerfilId).First();

                return usuarioRegistrado;
            }
            catch (Exception ex)
            {
                Usuarios usuarios = new Usuarios();
                return usuarios;
            }
        }

        public Usuarios ActualizaUsuario(Usuarios usuario)
        {
            try
            {
                _dbContext.Usuarios.Update(usuario);
                _dbContext.SaveChanges();

                Usuarios usuarioActualizado = _dbContext.Usuarios.Where(u => u.Id == usuario.Id).First();

                return usuarioActualizado;
            }
            catch (Exception ex)
            {
                Usuarios usuarios = new Usuarios();
                return usuarios;
            }
        }

        public UsuarioAcceso RegistraAcceso(UsuarioAcceso usuarioAcceso)
        {
            try
            {
                _dbContext.UsuarioAcceso.Add(usuarioAcceso);
                _dbContext.SaveChanges();

                var accesoRegistrado = _dbContext.UsuarioAcceso.Where(u => u.NombreUsuario.ToLower() == usuarioAcceso.NombreUsuario.ToLower()).First();

                return accesoRegistrado;
            }
            catch (Exception ex)
            {
                UsuarioAcceso usuarioAccesoR = new UsuarioAcceso();
                return usuarioAccesoR;
            }
        }
    }
}
