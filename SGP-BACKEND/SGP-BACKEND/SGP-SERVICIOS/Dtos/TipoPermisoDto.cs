using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGP_SERVICIOS.Dtos
{
    public class TipoPermisoDto
    { 
        public int Id { get; set; }
         
        public string NombreTipoPermiso { get; set; }
    }
}
