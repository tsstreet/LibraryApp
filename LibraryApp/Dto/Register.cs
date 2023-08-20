using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Dto
{
    public class Register
    {
        [Key]
        public int StdId { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public DateTime Dob { get; set; }
        public string? ParentName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        [Required]
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }

        [Required, MinLength(6)]
        public string? Password { get; set; }
    }
}
