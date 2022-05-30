using ProyectoAyure.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Repositorios.IRepositorio
{
    public interface IUsuarioAccesoRepositorio
    {
        public UsuarioAcceso ValidaInicioSesion(UsuarioAcceso usuarioSesion);
    }
}
