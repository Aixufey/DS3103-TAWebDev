// Add sqlite -> dotnet add package Microsoft.EntityFrameworkCore.Sqlite
// Add query tool -> dotnet tool install -g dotnet-ef

#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Sqlite;
using imdb.Models;
using imdb.Contexts;
using Microsoft.EntityFrameworkCore;

namespace imdb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieContext context;

    // Auto Wire context and inject into MovieController constructor as dependency in order to act as DAO.
    public MovieController(MovieContext _context)
    {
        context = _context;
    }

    private List<Movie> movies = new List<Movie>
    {
        new Movie {
            Id = 1000,
            Title = "Conjuring 2",
            Year = "2018",
            Rating = "3/5"
        }
    };

    [HttpGet("[action]")]
    public async Task<ActionResult<List<Movie>>> GetAllMovies()
    {
        try
        {
            List<Movie> movies = await context.Movie.ToListAsync();
            return Ok(movies);
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<ActionResult<Movie>> GetById(int id)
    {
        Movie movie = await context.Movie.FindAsync(id);
        if (movie != null)
        {
            return Ok(movie);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [Route("[action]")]
    public async Task< ActionResult > Post(Movie newMovie)
    {
        try 
        {
            context.Movie.Add(newMovie);
            await context.SaveChangesAsync();
            // Surrogate key autoincrement
            return CreatedAtAction(nameof(GetById), new { id = newMovie.Id }, newMovie);
        }
        catch
        {
            return StatusCode(500);
        }
    }

    
}
