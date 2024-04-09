using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGP_ENTIDADES.Entidades
{
    public class Permisos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreEmpleado { get; set; }

        [Required]
        [StringLength(50)]
        public string ApellidosEmpleado { get; set; }

        public int TipoPermiso { get; set; }

        [ForeignKey("TipoPermiso")]
        public TipoPermiso Tipo { get; set; }

        [Required]
        public DateTime FechaPermiso { get; set; }
    }
}
