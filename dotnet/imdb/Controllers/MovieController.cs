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
[Route("api/[controller]")] // annotate the endpoint as api/Movie
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

    [HttpGet("[action]")] // api/Movie/GetAllMovies
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
    [Route("[action]/{id}")] // api/Movie/GetById/{id}
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
    [Route("[action]")] // api/Movie/Post
    public async Task< ActionResult > Post([FromBody] Movie newMovie)
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



    private readonly List<Actor> actors = new List<Actor>
    {
        new Actor {
            Id = 1000,
            Name = "Christian Bale",
            Age = "45"
        }
    };
    [HttpGet]
    [Route("[action]")]
    public async Task<ActionResult<List<Actor>>> GetAllActors()
    {
        try
        {
            
            return Ok(actors);
        }
        catch
        {
            return StatusCode(500);
        }
    }
    
}
