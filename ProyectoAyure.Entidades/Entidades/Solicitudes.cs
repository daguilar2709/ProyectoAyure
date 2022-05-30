using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAyure.Data.Entidades
{
    public class Solicitudes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int NumeroSolicitud { get; set; }
        [MaxLength(250)]
        public string NumeroTicket { get; set; }
        public int? usuarioAmbientalista { get; set; }
        public int? usuarioRecolector { get; set; }
        public int? usuarioCentroReciclaje { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public bool Activo { get; set; }

    }
}
