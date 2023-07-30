using DemoAPI.Data;
using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    readonly AppDbContext _context;

    public MovieController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetList/{id}")]
    public async Task<ActionResult<MovieList>> GetList(int id)
    {
        
            MovieList? list = await _context.MovieLists!.Include(ml => ml.Movies).Where(ml => ml.Id == id)
                .SingleOrDefaultAsync();

            if (list!.Movies.Count > 0)
            {
                return Ok(list);
            }
        

            return NotFound();

    }

    [HttpGet("GetMovie/{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        
            var movie = await _context.Movies!.Where(m => m.Id == id).SingleOrDefaultAsync();
            if (movie != null)
            {
                return Ok(movie);
            }
        
            return NotFound();

    }

    [HttpPost("AddList")]
    public async Task<ActionResult> AddList(AddMovieList model)
    {
        var newList = new MovieList { Date = DateTime.Now, Name = model.Name, };

        if (_context.MovieLists != null)
        {
            await _context.MovieLists.AddAsync(newList);
            await _context.SaveChangesAsync();
            return Ok("list created");
        }

        return StatusCode(500);

    }

    [HttpPost("AddMovie")]
    public async Task<ActionResult> AddMovie(AddMovie model)
    {

        int listId;

        if (model.ListId == 0)
        {
            // create a new list
            var list = new MovieList { Date = DateTime.Now, Name = model.Name };
            await _context.MovieLists!.AddAsync(list);
            await _context.SaveChangesAsync();
            listId = list.Id;
        }
        else
        {
            listId = model.ListId;
        }
        

        var movie = new Movie { Date = DateTime.Now, Name = model.Name, MovieListId = listId};
        
        
            await _context.Movies!.AddAsync(movie);
            await _context.SaveChangesAsync();
            return Ok($"Saved movie {model.Name} to list {listId}");
        
    }

    [HttpDelete("DeleteMovie/{id}")]
    public async Task<ActionResult> DeleteMovie(int id)
    {
        var movie = await _context.Movies!.Where(m => m.Id == id).SingleOrDefaultAsync();
        if (movie is null)
        {
            return NotFound($"Could not find movie with id {id}");
        }

        _context.Movies!.Remove(movie);
        await _context.SaveChangesAsync();
        return Ok($"Deleted movie with id {id}");

    }

    [HttpDelete("DeleteList/{id}")]
    public async Task<ActionResult> DeleteList(int id)
    {
        var list = await _context.MovieLists!.Where(ml => ml.Id == id).SingleOrDefaultAsync();
        if (list is null)
        {
            return NotFound($"Could not find movielist with id {id}");
        }

        _context.MovieLists!.Remove(list);

        await _context.SaveChangesAsync();
        return Ok($"Deleted list with id {id}");

    }
}