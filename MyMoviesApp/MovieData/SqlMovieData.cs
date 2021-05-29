using MyMoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoviesApp.MovieData
{
    public class SqlMovieData : IMovieData
    {
        private MovieContext _movieContext;

        public SqlMovieData(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public Movie AddMovie(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();
            return movie;
        }

        public void DeleteMovie(Movie movie)
        {
            _movieContext.Movies.Remove(movie);
            _movieContext.SaveChanges();
        }

        public Movie EditMovie(Movie movie)
        {
            var existingMovie = _movieContext.Movies.Find(movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.YearOfProduction = movie.YearOfProduction;
                _movieContext.Movies.Update(existingMovie);
                _movieContext.SaveChanges();
            }
            return movie;
        }

        public Movie GetMovie(Guid id)
        {
            var movie = _movieContext.Movies.Find(id);
            return movie;
        }

        public List<Movie> GetMovies()
        {
            return _movieContext.Movies.ToList();
        }
    }
}
