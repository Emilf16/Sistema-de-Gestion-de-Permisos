using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SGP_DATOS;
using SGP_SERVICIOS.Dtos;
using SGP_SERVICIOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGP_SERVICIOS.Repositorios
{
    public class TipoPermisoRepositorio : ITipoPermiso
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public TipoPermisoRepositorio(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IEnumerable<TipoPermisoDto>> GetTiposPermiso(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                descripcion = "";
            }
            var tiposPermisos = await _context.TipoPermiso.Where(x => x.Descripcion.Trim().ToUpper().Contains(descripcion.Trim().ToUpper())).Select(x => new TipoPermisoDto
            {
                Id = x.Id,
                NombreTipoPermiso = x.Descripcion


            }).ToListAsync();

            return tiposPermisos;
        }
    }
}
