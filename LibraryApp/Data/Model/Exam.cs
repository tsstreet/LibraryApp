using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        public string? Form { get; set; }

        [Required]
        public string? Creator { get; set; }

        [Required]
        public string? Duration { get; set; }

        [Required]
        public string? Status { get; set; }

        [Required]

        public int DepartmentId { get; set; }

        [Required]

        public int SubjectId { get; set; }
    }
}
