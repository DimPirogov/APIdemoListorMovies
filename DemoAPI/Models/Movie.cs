using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPI.Models;

public class Movie
{
    public int Id { get; set; }

    public DateTime Date { get; set; }
    public string Name { get; set; } = string.Empty;

    [ForeignKey("MovieListId")]
    public int MovieListId { get; set; }
    public MovieList? MovieList { get; set; }
}
