using Lab2.Data;
using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers;

[Route("[action]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly EntertainmentDbContext _dbContext;

    public TestController(EntertainmentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> HighestGrossingMovies()
    {
        List<Movie> movies = await _dbContext
            .Productions.OfType<Movie>()
            .OrderByDescending(x => x.WorldwideBoxOfficeGross)
            .ToListAsync();

        return Ok(movies);
    }

    [HttpGet]
    public async Task<IActionResult> HighestRatedProductions()
    {
        var highestRated = await _dbContext
         .Productions
         .Select(x => new
         {
             id = x.Id,
             name = x.Name,
             avg = x.Ratings.Average(r => r.Stars),
             type = x.GetType().Name
         })
         .OrderByDescending(x => x.avg)
         .ToListAsync();

        return Ok(highestRated);
    }

    [HttpGet]
    public async Task<IActionResult> SourcesOfRatingsByCount()
    {
        var sources = await _dbContext
            .Ratings
            .GroupBy(x => x.Source)
            .Select(x => new { Source = x.Key, Count = x.Count() })
            .OrderByDescending(x => x.Count)
            .ToListAsync();

        return Ok(sources);
    }

    [HttpGet]
    public async Task<IActionResult> SeriesWithTheFewestEpisodes()
    {
        var episodes = await _dbContext
            .Series
            .OrderBy(x => x.NumberOfEpisodes)
            .Select(x => new {
                x.Name,
                x.NumberOfEpisodes,
                x.Release
            })
            .Take(1)
            .ToListAsync();

        return Ok(episodes);
    }

    [HttpGet]
    public async Task<IActionResult> ProductionsWithTheInName()
    {
        List<Production> productionsWithTheInName = await _dbContext
            .Productions
            .Where(x => x.Name.Contains("The"))
            .ToListAsync();

        return Ok(productionsWithTheInName);
    }

    [HttpGet]
    public async Task<IActionResult> ActorsPlayingCharactersInMultipleProductions()
    {
        var multipleCharacters = await _dbContext
            .Actors
            .Where(a => a.Characters.Count > 1)
            .Select(a => new {
                a.Name,
                Characters = a.Characters.Select(x => new {
                    Name = x.Name,
                    ProductionType = x.Production.GetType().Name
                })
                .OrderBy(x => x.Name)
                .ToList()
            }).ToListAsync();

        return Ok(multipleCharacters);
    }
}