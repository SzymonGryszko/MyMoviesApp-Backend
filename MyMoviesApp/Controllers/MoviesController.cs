using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMoviesApp.Models;
using MyMoviesApp.MovieData;
using System;

namespace MyMoviesApp.Controllers
{
    
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieData _movieData;
        public MoviesController(IMovieData movieData)
        {
            _movieData = movieData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetMovies()
        {
            return Ok(_movieData.GetMovies());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetMovie(int id)
        {

            var movie = _movieData.GetMovie(id);
            
            if(movie != null)
            {
                return Ok(movie);
            }

            return NotFound($"Movie with Id: {id} was not found");

        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddMovie(Movie movie)
        {

            var newMovie = _movieData.AddMovie(movie);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + newMovie.Id, newMovie);

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteMovie(int id)
        {

            var movie = _movieData.GetMovie(id);

            if(movie != null)
            {
                _movieData.DeleteMovie(movie);
                return Ok();
            }

            return NotFound($"Movie with Id: {id} was not found");

        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditMovie(int id, Movie movie)
        {
            var existingMovie = _movieData.GetMovie(id);

            if (existingMovie != null)
            {
                movie.Id = existingMovie.Id;
                _movieData.EditMovie(movie);
                return Ok(movie);
            }

            return NotFound($"Movie with Id: {id} was not found");
        }

    }
}
