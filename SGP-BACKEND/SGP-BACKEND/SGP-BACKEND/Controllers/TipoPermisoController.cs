using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGP_SERVICIOS.Common;
using SGP_SERVICIOS.Dtos;
using SGP_SERVICIOS.Repositorios;

namespace SGP_BACKEND.Controllers
{
    [Route("TipoPermiso")]
    [ApiController]
    public class TipoPermisoController : ControllerBase
    {
        private readonly TipoPermisoRepositorio _tipoPermisoRepositorio;

        public TipoPermisoController(TipoPermisoRepositorio tipoPermisoRepositorio)
        {
            _tipoPermisoRepositorio = tipoPermisoRepositorio;
        }


        /// <summary>
        /// Permite consultar todo los tipos de permisos disponibles.
        /// </summary>
        /// <param nombre="nombre">Permite buscar por nombre,dejarlo vacio retorna todos</param>
        [HttpGet]
        public async Task<OperationResult> GetTiposPermiso(string? nombre)
        {
            try
            {
                var tiposPermisos = await _tipoPermisoRepositorio.GetTiposPermiso(nombre);

                return new OperationResult(true, "Listado obtenido de manera exitosa.", tiposPermisos);
            }
            catch (Exception ex)
            {

                return new OperationResult(false, ex.Message);
            }
        }
       
    }
}