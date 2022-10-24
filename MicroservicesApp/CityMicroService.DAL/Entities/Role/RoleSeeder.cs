using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityMicroService.DAL.Entities;

internal class RoleSeeder : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(new List<Role>()
        {
            new() {Id = 1, Name = "Role 1"},
            new() {Id = 2, Name = "Role 2"},
            new() {Id = 3, Name = "Role 3"},
        });
    }
}