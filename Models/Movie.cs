using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace Movies.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public String Name { get; set; } =  String.Empty;
        [Required(ErrorMessage ="Please enter a year")]
        [Range(1900,2024,ErrorMessage ="Year must be between 1900 and 2024")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Please enter a Rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int? Rating { get; set; }
        [Required(ErrorMessage = "Please enter a Genre")]

        public string Slug => Name?.Replace(' ','-').ToLower() + '-' + Year?.ToString();
        public string GenreId { get; set; } = String.Empty;


        [ValidateNever]
        public Genre Genre { get; set; } = null!;
    }
}
