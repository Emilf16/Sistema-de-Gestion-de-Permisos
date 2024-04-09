using SGP_SERVICIOS.Common;
using SGP_SERVICIOS.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGP_SERVICIOS.Interfaces
{
    public interface ITipoPermiso
    {
        Task<IEnumerable<TipoPermisoDto>> GetTiposPermiso(string descripcion); 
    }
}
