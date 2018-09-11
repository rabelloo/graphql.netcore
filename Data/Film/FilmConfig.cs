using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Core;

namespace StarWars.Data
{
    public class FilmConfig : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => d.Episode).IsUnique();
            builder.HasIndex(d => d.Title).IsUnique();
            builder.Property(d => d.Title).HasMaxLength(256);
        }
    }
}
