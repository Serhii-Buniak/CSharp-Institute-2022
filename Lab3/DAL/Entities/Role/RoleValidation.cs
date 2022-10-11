using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities;

internal class RoleValidation : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasAlternateKey(p => p.Name);
    }
}