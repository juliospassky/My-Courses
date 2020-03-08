using GTSharp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GTSharp.Infra.Persistence.Map
{
    public class MapUser : EntityTypeConfiguration<GTUser>
    {
        public MapUser()
        {
            ToTable("GTSUser");

            Property(o => o.Email.Adress).HasMaxLength(200).IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute( "UK_USER_EMAIL") { IsUnique = true}))
                .HasColumnName("Email");

            Property(o => o.Name.FirstName).HasMaxLength(50).IsRequired().HasColumnName("FirstName");
            Property(o => o.Name.LastName).HasMaxLength(50).IsRequired().HasColumnName("LastName");
            Property(o => o.Password).IsRequired();
            Property(o => o.Status).IsRequired();
        }
    }
}
