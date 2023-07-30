namespace DemoAPI.Models;

public class MovieList
{
    public int Id { get; set; }

    public DateTime Date { get; set; }
    public string? Name { get; set; }

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
