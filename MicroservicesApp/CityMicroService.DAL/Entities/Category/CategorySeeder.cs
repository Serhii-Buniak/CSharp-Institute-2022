using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityMicroService.DAL.Entities;

internal class CategorySeeder : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(new List<Category>()
        {
            new() {Id = 1, Name = "Category 1"},
            new() {Id = 2, Name = "Category 2"},
            new() {Id = 3, Name = "Category 3"},
        });
    }
}