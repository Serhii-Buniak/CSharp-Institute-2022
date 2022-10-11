using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class GalleryConfiguration : IEntityTypeConfiguration<Gallery>
{
    public void Configure(EntityTypeBuilder<Gallery> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(p => p.Name)
            .IsUnique();

        builder.HasData(new List<Gallery>()
        {
            new(){Id = 1, Name = "Gallery 1"},
            new(){Id = 2, Name = "Gallery 2"},
            new(){Id = 3, Name = "Gallery 3"},
        });
    }
}
