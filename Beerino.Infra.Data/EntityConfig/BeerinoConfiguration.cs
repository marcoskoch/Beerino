using Beerino.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Beerino.Infra.Data.EntityConfig
{
    public class BeerinoConfiguration : EntityTypeConfiguration<BeerinoUser>
    {
        public BeerinoConfiguration()
        {
            HasKey(p => p.BeerinoUserID);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(250);

            HasRequired(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);
        }
    }
}
