using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityMicroService.DAL.Entities;

internal class EventValidation : IEntityTypeConfiguration<Event>
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
    }
}