using ProyectoAyure.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Repositorios.IRepositorio
{
    public interface IPerfilRepositorio
    {
        List<Perfiles> GetPerfiles();
        Perfiles ObtienePerfil(int idPerfil);
        bool RegistraPerfil(Perfiles perfil);
        bool EditaPerfil(Perfiles perfil);
        bool EliminaPerfil(int idPerfil);
    }
}
