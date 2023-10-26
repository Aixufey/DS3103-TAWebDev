// PK for surrogate key
using System.ComponentModel.DataAnnotations;
using imdb.Interfaces;
namespace imdb.Models;



public class Movie: IMovie
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Year { get; set; } = "";
    public string Rating { get; set; } = "";
}