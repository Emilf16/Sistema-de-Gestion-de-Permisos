using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGP_SERVICIOS.Dtos
{
    public class PermisoDto
    { 
        public int Id { get; set; }
         
        public string Nombre { get; set; } 

        public string Apellido { get; set; }

        public int Permiso { get; set; }
          
        public DateTime Fecha { get; set; }
    }
}
