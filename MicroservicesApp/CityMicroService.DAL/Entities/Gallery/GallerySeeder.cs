using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityMicroService.DAL.Entities;

internal class GallerySeeder : IEntityTypeConfiguration<Gallery>
{
    public void Configure(EntityTypeBuilder<Gallery> builder)
    {
        builder.HasData(new List<Gallery>()
        {
            new(){Id = 1, Name = "Gallery 1"},
            new(){Id = 2, Name = "Gallery 2"},
            new(){Id = 3, Name = "Gallery 3"},
        });
    }
}