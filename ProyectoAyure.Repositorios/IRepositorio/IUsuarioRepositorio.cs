using ProyectoAyure.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Repositorios.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        Usuarios ObtieneUsuario(int idUsuario);
        List<Usuarios> ObtieneUsuarios();
        Usuarios RegistraUsuario(Usuarios usuario, int PerfilId);
        Usuarios ActualizaUsuario(Usuarios usuario);
        UsuarioAcceso RegistraAcceso(UsuarioAcceso usuarioAcceso);
    }
}
