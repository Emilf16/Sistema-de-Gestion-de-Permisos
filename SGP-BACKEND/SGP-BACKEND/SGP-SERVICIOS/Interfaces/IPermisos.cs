using SGP_SERVICIOS.Common;
using SGP_SERVICIOS.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGP_SERVICIOS.Interfaces
{
    public interface IPermisos
    {
        Task<IEnumerable<PermisoDto>> GetPermisos(string descripcion);
        Task<OperationResult> GetPermisoPorId(int permisoId);
        Task<OperationResult> DeletePermisoPorId(int permisoId);
        Task<OperationResult> CrearPermiso(PermisoDto permisoModel);
        Task<OperationResult> ActualizarPermiso(PermisoDto permisoModel, int permisoId); 
    }
}
