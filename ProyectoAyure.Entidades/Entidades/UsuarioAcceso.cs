using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Data.Entidades
{
    public class UsuarioAcceso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; }
        [Required]
        [MaxLength(50)]
        public string Constraseña { get; set; }
        public Guid Identificador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Activo { get; set; }

        public int? usuarioId { get; set; }
        [ForeignKey("usuarioId")]
        public Usuarios? usuarios { get; set; }
    }
}
