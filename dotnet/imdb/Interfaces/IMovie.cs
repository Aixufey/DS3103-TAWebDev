namespace imdb.Interfaces;

public interface IMovie
{
    int Id { get; set; }
    string Title { get; set; }
    string Year { get; set; }
    string Rating { get; set; }
}