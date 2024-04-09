using Microsoft.EntityFrameworkCore;
using SGP_DATOS.Mapping;
using SGP_ENTIDADES.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SGP_DATOS
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<TipoPermiso> TipoPermiso { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new PermisosMap());
            modelBuilder.ApplyConfiguration(new TipoPermisoMap()); 
        }
    }
}
