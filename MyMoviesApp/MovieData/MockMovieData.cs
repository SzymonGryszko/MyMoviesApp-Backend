

using MyMoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMoviesApp.MovieData
{
    public class MockMovieData : IMovieData
    {

        private List<Movie> movies = new List<Movie>()
        {
            new Movie()
            {
                Id = Guid.NewGuid(),
                Title = "Test Movie 1",
                YearOfProduction = 1999
            },
            new Movie()
            {
                Id = Guid.NewGuid(),
                Title = "Test Movie 2",
                YearOfProduction = 2002
            }
        };

        public Movie AddMovie(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            movies.Add(movie);
            return movie;
        }

        public void DeleteMovie(Movie movie)
        {
            movies.Remove(movie);
        }

        public Movie EditMovie(Movie movie)
        {
            var existingMovie = GetMovie(movie.Id);
            existingMovie.Title = movie.Title;
            if(movie.YearOfProduction != null) 
            {
                existingMovie.YearOfProduction = movie.YearOfProduction;
            }
            else
            {
                existingMovie.YearOfProduction = null;
            }

            return existingMovie;
            
        }

        public Movie GetMovie(Guid id)
        {
            return movies.SingleOrDefault(movie => movie.Id == id);
        }

        public List<Movie> GetMovies()
        {
            return movies;
        }
    }
}
