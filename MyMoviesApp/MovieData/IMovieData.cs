using MyMoviesApp.Models;
using System;
using System.Collections.Generic;


namespace MyMoviesApp.MovieData
{
    public interface IMovieData
    {
        List<Movie> GetMovies();

        Movie GetMovie(Guid id);

        Movie AddMovie(Movie movie);

        void DeleteMovie(Movie movie);

        Movie EditMovie(Movie movie);
    }
}
