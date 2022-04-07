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
    public class PerfilServicio : IPerfilServicio
    {
        private IPerfilRepositorio _iPerfilRepositorio;

        public PerfilServicio(IPerfilRepositorio perfilRepositorio)
        {
            _iPerfilRepositorio = perfilRepositorio;
        }

        public List<PerfilViewModel> ObtienePerfiles()
        {
            List<PerfilViewModel> lstperfilVM = new List<PerfilViewModel>();
            try
            {
                List<Perfiles> lstPerfil = _iPerfilRepositorio.GetPerfiles();
                foreach (var perfil in lstPerfil)
                {
                    lstperfilVM.Add(new PerfilViewModel() { Id= perfil.Id, NombrePerfil= perfil.NombrePerfil, Activo = perfil.Activo });
                }

                return lstperfilVM;
            }
            catch (Exception ex)
            {
                return lstperfilVM;
            }
        }

        public bool RegistraPerfil(PerfilViewModel perfilVM)
        {
            try
            {
                Perfiles perfil = new Perfiles();
                perfil.NombrePerfil = perfilVM.NombrePerfil;
                perfil.Activo = perfilVM.Activo;

                _iPerfilRepositorio.RegistraPerfil(perfil);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditaPerfil(PerfilViewModel perfilVM)
        {
            try
            {
                Perfiles perfil = new Perfiles();
                perfil.Id = perfilVM.Id;
                perfil.NombrePerfil = perfilVM.NombrePerfil;
                perfil.Activo = perfilVM.Activo;

                var PerfilActualizado = _iPerfilRepositorio.EditaPerfil(perfil);

                if (PerfilActualizado)
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

        public bool EliminaPerfil(int idPerfil)
        {
            try
            {
                _iPerfilRepositorio.EliminaPerfil(idPerfil);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
