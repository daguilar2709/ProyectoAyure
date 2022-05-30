using ProyectoAyure.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Data.ViewModels
{
    public class UsuarioAccesoViewModel
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public Guid Identificador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Activo { get; set; }

        public UsuarioViewModel? usuarios { get; set; }
    }
}
