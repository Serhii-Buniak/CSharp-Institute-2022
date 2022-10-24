using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityMicroService.DAL.Entities;

internal class ImageSeeder : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasData(new List<Image>()
        {
            new() {Id = 1, Name="Image 1", GalleryId = 1},
            new() {Id = 2, Name="Image 2", GalleryId = 2},
            new() {Id = 3, Name="Image 3", GalleryId = 2},
            new() {Id = 4, Name="Image 4", GalleryId = 3},
            new() {Id = 5, Name="Image 5", GalleryId = 3},
            new() {Id = 6, Name="Image 6", GalleryId = 3},
        });
    }
}