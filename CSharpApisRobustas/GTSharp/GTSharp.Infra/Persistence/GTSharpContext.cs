using GTSharp.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GTSharp.Infra.Persistence
{
    public class GTSharpContext : DbContext
    {
        public GTSharpContext() : base("GTSharp")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove a pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Remove exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Setar para usar varchar ao invés de nvchar
            modelBuilder.Properties<string>().Configure(o => o.HasColumnType("varchar"));

            //Caso esqueca de setar o tamanho do campo, define como varchar 100
            modelBuilder.Properties<string>().Configure(o => o.HasMaxLength(100));

            //Adiciona entidades mapeadas
            modelBuilder.Configurations.AddFromAssembly(typeof(GTSharpContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
