using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Genre
    {
        [Key]
        public string GenereId { get; set; }
        public string GenereName { get; set; }
    }
}
