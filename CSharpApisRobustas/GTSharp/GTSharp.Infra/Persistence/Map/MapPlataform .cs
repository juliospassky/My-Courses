using GTSharp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GTSharp.Infra.Persistence.Map
{
    public class MapPlataform : EntityTypeConfiguration<Platform>
    {
        public MapPlataform()
        {
            ToTable("Plataform");

            Property(o => o.Name).HasMaxLength(50).IsRequired();
        }
    }
}
