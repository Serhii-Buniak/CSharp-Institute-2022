using Lab1.Data;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieContext _movieContext;

    public MovieController(MovieContext movieContext)
    {
        _movieContext = movieContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetMovies()
    {
        if (_movieContext.Movies == null || _movieContext.Movies.Any() == false)
        {
            return NotFound();
        }
        var movies = await _movieContext.Movies.ToListAsync();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovie(int id)
    {
        if (_movieContext.Movies == null)
        {
            return NotFound();
        }

        var movie = await _movieContext.Movies.FindAsync(id);
        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie(Movie movie)
    {
        _movieContext.Movies.Add(movie);
        await _movieContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, Movie movie)
    {
        if (id != movie.Id)
        {
            return BadRequest();
        }

        _movieContext.Entry(movie).State = EntityState.Modified;

        try
        {
            await _movieContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieExist(id))
            {
                NotFound();
            }

            throw;
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        if (_movieContext.Movies == null)
        {
            return NotFound();
        }

        var movie = await _movieContext.Movies.FindAsync(id);
        if (movie == null)
        {
            return NotFound();
        }

        _movieContext.Movies.Remove(movie);
        await _movieContext.SaveChangesAsync();

        return NoContent();
    }


    private bool MovieExist(int id)
    {
        return _movieContext.Movies.Any(x => x.Id == id);
    }
}