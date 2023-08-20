using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Dto
{
    public class TeacherDto
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        public string? TeacherCode { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        public string? Address { get; set; }

        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public string? MainSubject { get; set; }

        public string? Password { get; set; }
    }
   
}
