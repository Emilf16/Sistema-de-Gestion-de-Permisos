using SGP_DATOS;
using SGP_SERVICIOS.Common;
using SGP_SERVICIOS.Dtos;
using SGP_SERVICIOS.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGP_ENTIDADES.Entidades;

namespace SGP_SERVICIOS.Repositorios
{
    public class PermisosRepositorio : IPermisos
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public PermisosRepositorio(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<OperationResult> ActualizarPermiso(PermisoDto permisoModel, int permisoId)
        {
            if (permisoId != permisoModel.Id)
            {
                return new OperationResult(false, "El Id no coincide con el modelo.", permisoModel.Id);
            }


            var permiso = await _context.Permisos.Where(x => x.Id == permisoId).FirstOrDefaultAsync();
            if (permiso != null)
            {

                permiso.TipoPermiso = permisoModel.Permiso;
                permiso.NombreEmpleado = permisoModel.Nombre;
                permiso.ApellidosEmpleado = permisoModel.Apellido;
                permiso.FechaPermiso = permisoModel.Fecha;
                await _context.SaveChangesAsync();

                return new OperationResult(true, "Actualización Exitosa.", permiso.Id);
            }
            else
            {
                return new OperationResult(false, "No existe registro al cual se quiere actualizar.", permisoId);
            }
        }

        public async Task<OperationResult> CrearPermiso(PermisoDto permisoModel)
        {

            if (permisoModel.Id == 0)
            {
                var permiso = new Permisos
                {
                    NombreEmpleado = permisoModel.Nombre,
                    ApellidosEmpleado = permisoModel.Apellido,
                    FechaPermiso = permisoModel.Fecha,
                    TipoPermiso = permisoModel.Permiso

                };

                await _context.Permisos.AddAsync(permiso);

                await _context.SaveChangesAsync();

                return new OperationResult(true, "Resgistro Exitoso.", permiso.Id);
            }
            else
            {
                return new OperationResult(false, "Ya existe un registro con esta descripción.", 0);
            }

        }

        public async Task<OperationResult> DeletePermisoPorId(int permisoId)
        { 
            var permiso = await _context.Permisos.Where(x => x.Id == permisoId).FirstOrDefaultAsync();

            if (permiso == null)
            { 
                return new OperationResult(false, "Permiso no encontrado.", permisoId);
            }

            // Permiso found, proceed with deletion
            _context.Permisos.Remove(permiso);
            await _context.SaveChangesAsync();

            // Deletion successful, return success message
            return new OperationResult(true, "Permiso eliminado exitosamente.", permisoId);
        }

        public async Task<OperationResult> GetPermisoPorId(int permisoId)
        {
            var permiso = await _context.Permisos.Where(x => x.Id == permisoId).Select(x => new PermisoDto
            {
                Id = x.Id,
                Nombre = x.NombreEmpleado,
                Apellido = x.ApellidosEmpleado,
                Fecha = x.FechaPermiso,
                Permiso = x.TipoPermiso,

            }).FirstOrDefaultAsync();

            if (permiso != null)
            {

                return new OperationResult(true, "Permiso encontrado.", permiso);
            }
            else
            {
                return new OperationResult(false, "Permiso no encontrado.", permiso);

            }
        }

        public async Task<IEnumerable<PermisoDto>> GetPermisos(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                nombre = "";
            }

            var tiposPermisos = await _context.Permisos.Where(x =>
                x.NombreEmpleado.Trim().ToUpper().Contains(nombre.Trim().ToUpper()) ||
                x.ApellidosEmpleado.Trim().ToUpper().Contains(nombre.Trim().ToUpper())).Select(x => new PermisoDto
                {
                    Id = x.Id,
                    Nombre = x.NombreEmpleado,
                    Apellido = x.ApellidosEmpleado,
                    Fecha = x.FechaPermiso,
                    Permiso = x.TipoPermiso,

                }).ToListAsync();

            return tiposPermisos;
        }
    }
}
