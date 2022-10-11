using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.Property(p => p.CreateAt)
            .IsRequired();

        builder.HasData(new List<Message>()
        {
            new() {Id = 1, CreateAt = DateTime.Now, UserId = 1},
            new() {Id = 2, CreateAt = DateTime.Now, UserId = 1},
            new() {Id = 3, CreateAt = DateTime.Now, UserId = 1},
            new() {Id = 4, CreateAt = DateTime.Now, UserId = 2},
            new() {Id = 5, CreateAt = DateTime.Now, UserId = 3},
       });
    }
}