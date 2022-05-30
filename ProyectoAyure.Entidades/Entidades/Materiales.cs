using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Data.Entidades
{
    public class Materiales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NombreMaterial { get; set; }
        public string PrecioXKilo { get; set; }
        public bool Activo { get; set; }
    }
}
