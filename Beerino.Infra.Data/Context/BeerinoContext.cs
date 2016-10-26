using Beerino.Domain.Entities;
using Beerino.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Beerino.Infra.Data.Context
{
    public class BeerinoContext : DbContext
    {
        public BeerinoContext()
            : base("Beerino")
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<BeerinoUser> BeerinoUser { get; set; }
        public DbSet<Beer> Beer { get; set; }
        public DbSet<TaskBeer> TaskBeer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "ID")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new BeerinoConfiguration());
            modelBuilder.Configurations.Add(new BeerConfiguration());
            modelBuilder.Configurations.Add(new TaskBeerConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreationDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreationDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreationDate").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
