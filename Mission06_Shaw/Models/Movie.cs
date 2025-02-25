using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Shaw.Models
{
    // This makes a Movie class with all the data we need when someone enters in a new movie
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Release year must be 1888 or later.")]
        public int Year { get; set; } = 1888;

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Please select if the copy is edited or not")]
        public int Edited { get; set; }
        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Please confirm if it was copied to Plex")]
        public int CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}
