using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Student
    {
        [Key]
        public int StdId { get; set; }
        
        [Required]         
        public string StdCode { get; set; } = string.Empty;

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        public string? ParentName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }

        [Required, MinLength(6)]
        public string? Password { get; set; }
        public ICollection<ClassStudent> ClassStudents { get; set; }

        public void SetPassword(byte[] passwordHash, byte[] passwordSalt)
        {
            Password = Convert.ToBase64String(passwordHash) + ":" + Convert.ToBase64String(passwordSalt);
        }
    }
}
    

