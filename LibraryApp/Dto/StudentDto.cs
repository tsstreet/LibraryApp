using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Dto
{
    public class StudentDto
    {
        [Required]
        public string? StdCode { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Gender { get; set; }

        public string? Address { get; set; }
        public string? Phone { get; set; }

        [Required]
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
