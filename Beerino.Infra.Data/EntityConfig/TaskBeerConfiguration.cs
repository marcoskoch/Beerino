using Beerino.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Beerino.Infra.Data.EntityConfig
{
    public class TaskBeerConfiguration : EntityTypeConfiguration<TaskBeer>
    {
        public TaskBeerConfiguration()
        {
            HasKey(p => p.TaskBeerID);

            HasRequired(p => p.Beer)
                .WithMany()
                .HasForeignKey(p => p.BeerID);
        }
    }
}
