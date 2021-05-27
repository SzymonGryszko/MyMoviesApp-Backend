using System;

namespace MyMoviesApp.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int? YearOfProduction { get; set; }
    }
}
