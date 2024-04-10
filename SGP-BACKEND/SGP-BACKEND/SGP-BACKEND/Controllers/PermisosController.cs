using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGP_SERVICIOS.Common;
using SGP_SERVICIOS.Dtos;
using SGP_SERVICIOS.Repositorios;

namespace SGP_BACKEND.Controllers
{
    [Route("Permisos")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly PermisosRepositorio _permisosRepositorio;

        public PermisosController(PermisosRepositorio permisosRepositorio)
        {
            _permisosRepositorio = permisosRepositorio;
        }


        /// <summary>
        /// Permite consultar todo los tipos de permisos disponibles.
        /// </summary>
        /// <param name="nombre">Permite buscar por nombre,dejarlo vacio retorna todos</param>
        [HttpGet]
        public async Task<OperationResult> GetPermisos(string? nombre)
        {
            try
            {
                var permisos = await _permisosRepositorio.GetPermisos(nombre);

                return new OperationResult(true, "Listado obtenido de manera exitosa.", permisos);
            }
            catch (Exception ex)
            {

                return new OperationResult(false, ex.Message);
            }
        }
        /// <summary>
        /// Permite crear un nuevo permiso.
        /// </summary>
        /// <param name="permisoModel">Datos del nuevo permiso a crear.</param>
        /// <returns>Operation result.</returns>
        [HttpPost]
        public async Task<OperationResult> CrearPermiso([FromBody] PermisoDto permisoModel)
        {
            try
            {
                var permiso = await _permisosRepositorio.CrearPermiso(permisoModel);

                return permiso;
            }
            catch (Exception ex)
            {

                return new OperationResult(false, ex.Message);
            }
        }

        /// <summary>
        /// Permite borrar un permiso.
        /// </summary>
        /// <param name="id">Id del permiso a borrar.</param>
        /// <returns>Operation result.</returns>
        [HttpDelete("Borrar/{id}")]
        public async Task<OperationResult> DeletePermisoPorId(int id)
        {
            try
            {
                var permiso = await _permisosRepositorio.DeletePermisoPorId(id);

                return permiso;
            }
            catch (Exception ex)
            {

                return new OperationResult(false, ex.Message);
            }
        }

        /// <summary>
        /// Permite actualizar un permiso existente.
        /// </summary>
        /// <param name="id">Id del permiso a actualizar.</param>
        /// <param name="permisoModel">Datos actualizados del permiso.</param>
        /// <returns>Operation result.</returns>
        [HttpPut("{id}")]
        public async Task<OperationResult> ActualizarPermiso([FromBody] PermisoDto permisoModel, int id)
        {
            try
            {
                var permiso = await _permisosRepositorio.ActualizarPermiso(permisoModel, id);

                return permiso;
            }
            catch (Exception ex)
            {

                return new OperationResult(false, ex.Message);
            }
        }

        /// <summary>
        /// Permite obtener un permiso por su id.
        /// </summary>
        /// <param name="id">Id del permiso a buscar.</param> 
        /// <returns>Operation result.</returns>
        [HttpGet("{id}")]
        public async Task<OperationResult> GetPermisoPorId(int id)
        {
            try
            {
                var permiso = await _permisosRepositorio.GetPermisoPorId(id);

                return permiso;
            }
            catch (Exception ex)
            {

                return new OperationResult(false, ex.Message);
            }
        }

    }
}