using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        public string? TeacherCode { get; set; } 

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Falcuty { get; set; }

        [Required]
        public string? Gender { get; set; }

        public string? Address { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        public string? ImageUrl { get; set; }

        [MinLength(6)]
        public string? Password { get; set; }

        public ICollection<Subject> Subjects { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

        public void SetPassword(byte[] passwordHash, byte[] passwordSalt)
        {
            Password = Convert.ToBase64String(passwordHash) + ":" + Convert.ToBase64String(passwordSalt);
        }
    }
   
}
