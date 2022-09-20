using Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Data;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; } = null!;

    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {

    }
}
