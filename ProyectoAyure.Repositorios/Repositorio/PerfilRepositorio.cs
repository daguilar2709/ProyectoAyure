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
    public class PerfilRepositorio : IPerfilRepositorio
    {
        private readonly AyureDbContext _dbContext;

        public PerfilRepositorio(AyureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Perfiles> GetPerfiles()
        {
            List<Perfiles> lstPerfiles = new List<Perfiles>();
            
            try
            {
                lstPerfiles = _dbContext.Perfiles.ToList();
                return lstPerfiles;
            }
            catch (Exception ex)
            {
                return lstPerfiles;
            }
        }

        public Perfiles ObtienePerfil(int idPerfil)
        {
            Perfiles perfil = new Perfiles();

            try
            {
                perfil = _dbContext.Perfiles.Where(i => i.Id == idPerfil).First();
                return perfil;
            }
            catch (Exception ex)
            {
                return perfil;
            }
        }

        public bool RegistraPerfil(Perfiles perfil)
        {
            try
            {
                _dbContext.Perfiles.Add(perfil);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditaPerfil(Perfiles perfil)
        {
            try
            {
                var ExistePErfil = _dbContext.Perfiles.Where(p => p.NombrePerfil.ToLower() == perfil.NombrePerfil.ToLower()).First();

                if (ExistePErfil != null)
                {
                    _dbContext.Perfiles.Update(perfil);
                    _dbContext.SaveChanges();
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

        public bool EliminaPerfil(int idPerfil)
        {
            try
            {
                Perfiles perfil = _dbContext.Perfiles.Where(p => p.Id == idPerfil).First();
                _dbContext.Perfiles.Remove(perfil);
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
