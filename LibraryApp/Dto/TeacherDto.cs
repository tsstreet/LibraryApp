using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Dto
{
    public class TeacherDto
    {
        [Required]
        public string? TeacherCode { get; set; }


        [Required]
        public string? Falcuty { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Gender { get; set; }

        public string? Address { get; set; }

        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }

        public string? ImageUrl { get; set; }

        public string? Password { get; set; }
    }
   
}
