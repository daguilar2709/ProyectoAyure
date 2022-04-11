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
            List<Usuarios> lstUsers = new List<Usuarios>();
            List<Usuarios> lstUsuarios = new List<Usuarios>();

            try
            {
                lstUsers = _dbContext.Usuarios.ToList();
                foreach (var user in lstUsers)
                {
                    user.perfiles = new Perfiles();
                    user.perfiles = _dbContext.Perfiles.Where(p => p.Id == user.perfilId).First();
                    lstUsuarios.Add(user);
                }
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
                usuarios = _dbContext.Usuarios.AsNoTracking().Where(u => u.Id == idUsuario).First();
                usuarios.perfiles = new Perfiles();
                usuarios.perfiles = _dbContext.Perfiles.Where(p => p.Id == usuarios.perfilId).First();
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
                var dataUsuario = ObtieneUsuario(usuario.Id);
                usuario.FechaCreacion = dataUsuario.FechaCreacion;
                usuario.FechaModificacion = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
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

        public bool EliminaUsuario(int idUsuario)
        {
            try
            {
                Usuarios usuario = _dbContext.Usuarios.Where(u => u.Id == idUsuario).First();
                _dbContext.Usuarios.Remove(usuario);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
