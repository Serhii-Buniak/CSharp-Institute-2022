using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Data;

public class EntertainmentDbContext : DbContext
{
    public DbSet<Production> Productions { get; set; } = null!;
    public DbSet<Actor> Actors { get; set; } = null!;
    public DbSet<Rating> Ratings { get; set; } = null!;
    public DbSet<Series> Series { get; set; } = null!;

    public EntertainmentDbContext(DbContextOptions<EntertainmentDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Movie[] movies = {
            new() { Id = 1, Name = "Avengers: Endgame", WorldwideBoxOfficeGross = 2_797_800_564, DurationInMinutes = 181, Release = new DateTime(2019, 4, 26) },
            new() { Id = 2, Name = "The Lion King", WorldwideBoxOfficeGross = 1_654_791_102, DurationInMinutes     = 118, Release = new DateTime(2019, 7, 19) },
            new() { Id = 3, Name = "Ip Man 4", WorldwideBoxOfficeGross = 192_617_891, DurationInMinutes = 105, Release = new DateTime(2019, 12, 25) },
            new() { Id = 4, Name = "Gemini Man", WorldwideBoxOfficeGross = 166_623_705, DurationInMinutes = 116, Release = new DateTime(2019, 11, 20) },
            new() { Id = 5, Name = "Downton Abbey", WorldwideBoxOfficeGross = 194_051_302, DurationInMinutes = 120, Release = new DateTime(2020, 9, 20 )}
        };

        Series[] series = {
            new() { Id = 6 , Name = "The Fresh Prince of Bel-Air", NumberOfEpisodes = 148, Release = new DateTime(1990, 9, 10) },
            new() { Id = 7 , Name = "Downton Abbey", NumberOfEpisodes = 52, Release = new DateTime(2010, 09, 26) },
            new() { Id = 8 , Name = "Stranger Things", NumberOfEpisodes = 34 , Release = new DateTime(2016, 7, 11) },
            new() { Id = 9 , Name = "Kantaro: The Sweet Tooth Salaryman", NumberOfEpisodes = 12, Release = new DateTime(2017,7, 14) },
            new() { Id = 10, Name = "The Walking Dead", NumberOfEpisodes = 177 , Release = new DateTime(2010, 10, 31) }
        };

        List<Production> productions = movies
            .Cast<Production>()
            .Union(series)
            .ToList();

        modelBuilder.Entity<Movie>().HasData(movies);
        modelBuilder.Entity<Series>().HasData(series);

        modelBuilder.Entity<Actor>().HasData(new Actor[]
        {
            new() { Id = 1, Name = "Robert Downey Jr." },
            new() { Id = 2, Name = "Chris Evans" },
            new() { Id = 3, Name = "Danai Guira" },
            new() { Id = 4, Name = "Donald Glover" },
            new() { Id = 5, Name = "Beyoncé" },
            new() { Id = 6, Name = "Donny Yen" },
            new() { Id = 7, Name = "Will Smith" },
            new() { Id = 8, Name = "Maggie Smith" },
            new() { Id = 9, Name = "Michelle Dockery" },
            new() { Id = 10, Name = "Karyn Parsons" },
            new() { Id = 11, Name = "Millie Bobby Brown" },
            new() { Id = 12, Name = "Caleb McLaughlin" },
            new() { Id = 13, Name = "Winona Ryder"},
            new() { Id = 14, Name = "David Harbour" },
            new() { Id = 15, Name = "Matsuya Onoe" },
            new() { Id = 16, Name = "Hazuki Shimizu"},
            new() { Id = 17, Name = "Norman Reedus" },
            new() { Id = 18, Name = "Melissa McBride" }
        });

        var random = new Random();
        var size = 100;
        var sources = new[] {
            "Internet",
            "Newspaper",
            "Magazine",
            "App"
        };

        IEnumerable<Rating> ratings = productions
            .SelectMany((production, index) => {
                return Enumerable
                    .Range(index * 100 + 1, size - 1)
                    .Select(id => new Rating
                    {
                        Id = id,
                        ProductionId = production.Id,
                        Stars = random.Next(1, 6),
                        Source = sources[random.Next(0, 4)]
                    }).ToList();
            });

        modelBuilder.Entity<Rating>().HasData(ratings);

        base.OnModelCreating(modelBuilder);
    }
}