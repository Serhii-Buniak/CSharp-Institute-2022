using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasAlternateKey(p => p.Name);

        builder.HasData(new List<Role>()
        {
            new() {Id = 1, Name = "Role 1"},
            new() {Id = 2, Name = "Role 2"},
            new() {Id = 3, Name = "Role 3"},
        });
    }
}