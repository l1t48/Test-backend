using System.ComponentModel.DataAnnotations;

// Validation attributes ensure basic text validation (lengths and required fields).

namespace MyBackend.Dtos
{
    public class BookUpdateDto
    {
        [Required, StringLength(200)]
        public string Title { get; set; } = null!;
        
        [Required, StringLength(150)]
        public string Author { get; set; } = null!;
        
        [StringLength(2000)]
        public string? Description { get; set; }
    }
}