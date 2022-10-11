using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired();

        builder.HasIndex(p => p.Name)
            .IsUnique();

        builder.HasData(new List<Category>()
        {
            new() {Id = 1, Name = "Category 1"},
            new() {Id = 2, Name = "Category 2"},
            new() {Id = 3, Name = "Category 3"},
        });
    }
}