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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Validation
        builder.ApplyConfiguration(new CountryValidation());
        builder.ApplyConfiguration(new CityValidation());
        builder.ApplyConfiguration(new GalleryValidation());
        builder.ApplyConfiguration(new ImageValidation());
        builder.ApplyConfiguration(new RoleValidation());
        builder.ApplyConfiguration(new UserValidation());
        builder.ApplyConfiguration(new MessageValidation());
        builder.ApplyConfiguration(new EventValidation());
        builder.ApplyConfiguration(new CategoryValidation());
        #endregion

        #region SeedData
        builder.ApplyConfiguration(new CountrySeeder());
        builder.ApplyConfiguration(new CitySeeder());
        builder.ApplyConfiguration(new GallerySeeder());
        builder.ApplyConfiguration(new ImageSeeder());
        builder.ApplyConfiguration(new RoleSeeder());
        builder.ApplyConfiguration(new UserSeeder());
        builder.ApplyRoleUserSeeder();
        builder.ApplyConfiguration(new MessageSeeder());
        builder.ApplyConfiguration(new EventSeeder());
        builder.ApplyConfiguration(new CategorySeeder());
        builder.ApplyCategoryEventSeeder();
        #endregion

        base.OnModelCreating(builder);
    }
}