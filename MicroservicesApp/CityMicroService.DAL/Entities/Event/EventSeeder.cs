using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityMicroService.DAL.Entities;

internal class EventSeeder : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasData(new List<Event>()
        {
            new() {Id = 1, Name = "Event 1", UserId = 1, CityId = 1, GalleryId = 1,},
            new() {Id = 2, Name = "Event 2", UserId = 1, CityId = 1, GalleryId = 1,},
            new() {Id = 3, Name = "Event 3", UserId = 1, CityId = 1, GalleryId = 1,},
            new() {Id = 4, Name = "Event 4", UserId = 2, CityId = 2, GalleryId = 2,},
            new() {Id = 5, Name = "Event 5", UserId = 3, CityId = 3, GalleryId = 3,},
        });
    }
}