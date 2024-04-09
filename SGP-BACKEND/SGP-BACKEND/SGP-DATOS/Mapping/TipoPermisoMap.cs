using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SGP_ENTIDADES.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGP_DATOS.Mapping
{
    public class TipoPermisoMap : IEntityTypeConfiguration<TipoPermiso>
    {
        public void Configure(EntityTypeBuilder<TipoPermiso> builder)
        {
            builder.ToTable("TipoPermiso")
                .HasKey(x => x.Id);
        }
    }
}
