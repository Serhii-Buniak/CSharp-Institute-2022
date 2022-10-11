using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasOne(e => e.User)
            .WithMany(e => e.Events)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.HasIndex(p => p.Name)
            .IsUnique();

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