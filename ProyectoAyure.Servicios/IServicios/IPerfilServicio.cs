using ProyectoAyure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Servicios.IServicios
{
    public interface IPerfilServicio
    {
        List<PerfilViewModel> ObtienePerfiles();
        bool RegistraPerfil(PerfilViewModel perfilVM);
        bool EditaPerfil(PerfilViewModel perfilVM);
        bool EliminaPerfil(int idPerfil);
    }
}
