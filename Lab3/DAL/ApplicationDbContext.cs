using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<Gallery> Galleries { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(evnt =>
        {
            evnt
            .HasOne(e => e.User)
            .WithMany(e=> e.Events)
            .OnDelete(DeleteBehavior.NoAction);
        });

        base.OnModelCreating(modelBuilder);
    }
}