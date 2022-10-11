using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(p => p.Name)
               .HasMaxLength(50)
               .IsRequired();

        builder.HasIndex(p => p.Name)
            .IsUnique();

        builder.HasData(new List<Country>()
        {
            new() {Id = 1, Name = "Country 1"},
            new() {Id = 2, Name = "Country 2"},
            new() {Id = 3, Name = "Country 3"},
        });
    }
}
