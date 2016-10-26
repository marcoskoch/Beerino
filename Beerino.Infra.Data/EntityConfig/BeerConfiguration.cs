using Beerino.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Beerino.Infra.Data.EntityConfig
{
    public class BeerConfiguration : EntityTypeConfiguration<Beer>
    {
        public BeerConfiguration()
        {
            HasKey(p => p.BeerID);

            HasRequired(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserID);
        }
    }
}
