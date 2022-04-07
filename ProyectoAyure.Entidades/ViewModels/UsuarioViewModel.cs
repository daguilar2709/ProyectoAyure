using ProyectoAyure.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Data.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public int CodigoPostal { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public bool Activo { get; set; }
        public int perfilId { get; set; }
        public int usuarioAccesoId { get; set; }
    }
}
