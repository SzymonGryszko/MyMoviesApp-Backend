using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoviesApp.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(200,
            ErrorMessage = "Title can length cannot exceed 200 characters")]
        public string Title { get; set; }
        [Range(1900, 2100,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? YearOfProduction { get; set; }
    }
}
