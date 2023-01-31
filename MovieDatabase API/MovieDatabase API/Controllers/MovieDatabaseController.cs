using Microsoft.AspNetCore.Mvc;
using MovieDatabase_API.Db.Entities;
using MovieDatabase_API.Models;
using MovieDatabase_API.Repository;
namespace MovieDatabase_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieDatabaseController : ControllerBase
    {
        private readonly IMovieDatabaseRepository _MovieRepository;
        public MovieDatabaseController(IMovieDatabaseRepository movieRepository)
        {
            _MovieRepository = movieRepository;
        }

        [HttpPost]
        [Route("movie/add")]
        public async Task<IActionResult> add([FromBody] AddMovieRequest request)
        {
            await _MovieRepository.AddAsync(request);
            await _MovieRepository.SaveChangesAsync();
             return Ok();
        }
        [HttpGet]
        [Route("movie/get")]
        public async Task<IActionResult> get(int index)
        {
            var movie = _MovieRepository.GetById(index);
            await _MovieRepository.SaveChangesAsync();
            if (movie != null) return Ok("Succsesful Get");
            else return NotFound("User Not Found");
        }
        [HttpPost]
        [Route("movie/update")]
        public async Task<IActionResult> update([FromBody]UpdateMovieRequest request)
        {

            var movie= _MovieRepository.UpdateAsync(request);
            await _MovieRepository.SaveChangesAsync();
            if (movie != null) return Ok("Succsesful Update");
            else return NotFound("User Not Found");
            
        }
        [HttpDelete]
        [Route("movie/delete")]
        public async Task<IActionResult> delete([FromBody] DeleteMovieRequest request)
        {
            var movie=_MovieRepository.Delete(request);
            await _MovieRepository.SaveChangesAsync();
            if (movie != null) return Ok("Succsesful Delete");
            else return NotFound("User Not Found");
        }
       
    }
}
