using imdb.Models;
using Microsoft.EntityFrameworkCore;

namespace imdb.Contexts;
public class MovieContext: DbContext
{
    // Creating instance as MovieContext that allows ORM, abstract SQL queries
    public MovieContext( DbContextOptions<MovieContext> options): base (options) {}

    // Create Entity in database as Movie
    public DbSet<Movie> Movie { get; set; }
}