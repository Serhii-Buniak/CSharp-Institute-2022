using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityMicroService.DAL.Entities;

internal class ImageValidation : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(300)
            .IsRequired();

        builder.HasIndex(p => p.Name)
            .IsUnique();
    }
}