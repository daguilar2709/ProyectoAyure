using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Data.Entidades
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(75)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(100)]
        public string ApellidoPaterno { get; set; }
        [Required]
        [MaxLength(100)]
        public string ApellidoMaterno { get; set; }
        [MaxLength(250)]
        public string Direccion { get; set; }
        [MaxLength(75)]
        public string Telefono1 { get; set; }
        public string? Telefono2 { get; set; }
        public int CodigoPostal { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public bool Activo { get; set; }

        public int? perfilId { get; set; }
        [ForeignKey("perfilId")]
        public Perfiles? perfiles { get; set; }

        public int? usuarioAccesoId { get; set; }
        [ForeignKey("usuarioAccesoId")]
        public UsuarioAcceso? usuarioAcceso { get; set; }
    }
}
