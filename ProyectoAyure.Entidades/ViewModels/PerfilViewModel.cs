using ProyectoAyure.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Data.ViewModels
{
    public class PerfilViewModel
    {
        public int Id { get; set; }
        public string NombrePerfil { get; set; }
        public bool Activo { get; set; }
        public UsuarioViewModel? usuarios { get; set; }
    }
}
