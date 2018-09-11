using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Core;

namespace StarWars.Data
{
    public class DroidConfig : IEntityTypeConfiguration<Droid>
    {
        public void Configure(EntityTypeBuilder<Droid> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => d.Name).IsUnique();
            builder.Property(d => d.Name).HasMaxLength(64);
        }
    }
}
