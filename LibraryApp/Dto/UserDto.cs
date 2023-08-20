using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Data.Dto
{
    public class UserDto
    {

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
