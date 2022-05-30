using ProyectoAyure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Servicios.IServicios
{
    public interface IUsuarioAccesoServicio
    {
        public UsuarioAccesoViewModel ValidaUsuarioSesion(UsuarioAccesoViewModel usuarioSesion);
    }
}
