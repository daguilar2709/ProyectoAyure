using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Data.Entidades
{
    public class Perfiles
    {
        public Perfiles()
        {
            usuarios = new List<Usuarios>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(150)]
        public string NombrePerfil { get; set; }
        public bool Activo { get; set; }

        public ICollection<Usuarios> usuarios { get; set; }
    }
}
