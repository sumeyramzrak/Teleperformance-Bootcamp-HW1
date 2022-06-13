using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Odev1.Controllers
{

    [ApiController]
    [Route("api/[Controller]s")]
    public class MovieController : Controller
    {
 
        private static List<Movie> MovieList = MovieData.MovieList;

        //-----> GET

        [HttpGet]
        public IActionResult GetMovies()
        {

            var movieList = MovieList.OrderBy(x => x.Id).ToList<Movie>();
            return Ok(movieList);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = MovieList.Where(movie => movie.Id == id).SingleOrDefault();
            if (movie is null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        //[HttpGet]
        //public IActionResult Get([FromQuery] string id)
        //{
        //    var movie = MovieList.Where(book => book.Id == int.Parse(id)).SingleOrDefault();
        //    if (movie is null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(movie);
        //}

        [HttpGet("category/{CategoryId}")]
        public IActionResult GetByCategoryId(int? CategoryId)
        {
            var movieList = MovieList.Where(movie => movie.CategoryId==CategoryId).ToList<Movie>();
            if(movieList.Count==0)
            {
                return NotFound();
            }
            return Ok(movieList);
        }

        //-----> POST

        [HttpPost("Add")]
        public IActionResult AddMovie([FromBody] Movie newMovie)
        {
            var movie = MovieList.SingleOrDefault(x => x.Name == newMovie.Name);
            if (movie != null)
            {
                return BadRequest();
            }

            MovieList.Add(newMovie);
            return Created("movies",newMovie);
        }

        //-----> PUT

        [HttpPut("{id}/Update")]

        public IActionResult UpdateMovie(int id,[FromBody] Movie updatedMovie)

        {
            var movie=MovieList.SingleOrDefault(x => x.Id==id);

            if(movie is null)
            {
                return BadRequest();
            }

            movie.Name = updatedMovie.Name != default ? updatedMovie.Name : movie.Name;
            movie.Year=updatedMovie.Year != default ? updatedMovie.Year : movie.Year;
            movie.CategoryId=updatedMovie.CategoryId != default ? updatedMovie.CategoryId : movie.CategoryId;
            
            return Ok();
        }

        //-----> DELETE

        [HttpDelete("{id}/Delete")]

        public IActionResult DeleteMovie(int id)
        {
            var movie= MovieList.SingleOrDefault(x => x.Id==id);
            if( movie is null)
            {
                return BadRequest();
            }

            MovieList.Remove(movie);
            return Ok();
        }

        //-----> PATCH

        [HttpPatch("{id}")]

        public IActionResult ChangeCategory(int id, [FromBody] JsonPatchDocument<Movie> movie)
        {
            var data = MovieList.SingleOrDefault(m => m.Id == id);
            if(data != null)
            {
                data.CategoryId = 1;
            }
            else
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
