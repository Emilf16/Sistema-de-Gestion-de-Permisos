using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore; 
using SGP_ENTIDADES.Entidades;

namespace SGP_DATOS.Mapping
{
    public class PermisosMap : IEntityTypeConfiguration<Permisos>
    {
        public void Configure(EntityTypeBuilder<Permisos> builder)
        {
            builder.ToTable("Permisos")
                .HasKey(x => x.Id);
        }
    }
}
