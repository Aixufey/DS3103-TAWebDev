using imdb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace imdb.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController: ControllerBase
{
    private List<Movie> movies = new List<Movie>
    {
        new() {Id = 1000, Title = "The Conjuring 1", Year = "2014", Rating = "6.3"}
    };

    [HttpGet]
    public async Task<List<Movie>> GetAll()
    {
        return await Task.FromResult(movies);
    }
}