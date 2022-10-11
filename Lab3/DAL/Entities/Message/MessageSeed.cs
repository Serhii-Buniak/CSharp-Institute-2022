using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities;

internal class MessageSeeder : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasData(new List<Message>()
        {
            new() {Id = 1, CreateAt = new DateTime(2023, 10, 10), UserId = 1},
            new() {Id = 2, CreateAt = new DateTime(2023, 10, 10), UserId = 1},
            new() {Id = 3, CreateAt = new DateTime(2023, 10, 10), UserId = 1},
            new() {Id = 4, CreateAt = new DateTime(2023, 10, 10), UserId = 2},
            new() {Id = 5, CreateAt = new DateTime(2023, 10, 10), UserId = 3},
       });
    }
}