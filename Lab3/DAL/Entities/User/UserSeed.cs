using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities;

internal class UserSeeder : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new List<User>()
        {
            new() {
                Id = 1,
                FirstName="FirstName1",
                LastName = "LastName1",
                Email = "user1@email.com",
                Password = "Password1",
                Telephone = "00000000001",
                CityId = 1,
            },

            new() {
                Id = 2,
                FirstName="FirstName2",
                LastName = "LastName2",
                Email = "user2@email.com",
                Password = "Password2",
                Telephone = "00000000002",
                CityId = 2,
            },

            new() {
                Id = 3,
                FirstName="FirstName3",
                LastName = "LastName3",
                Email = "user3@email.com",
                Password = "Password3",
                Telephone = "00000000003",
                CityId = 3,
            },
        });
    }
}