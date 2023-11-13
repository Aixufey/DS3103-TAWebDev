using System.ComponentModel.DataAnnotations;
using imdb.Interfaces;
namespace imdb.Models;

public class Actor : IActor
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Age { get; set; } = "";
}