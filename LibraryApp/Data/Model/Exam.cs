using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Exam
    {

        [Key]
        public int ExamId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Form { get; set; }

        [Required]
        public string Creator { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public string Status { get; set; } = "waiting";

        [Required]

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        [Required]

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public bool IsApproved { get; set; } = false;

        public List<MultipleChoiceQuestion>? MultipleChoiceQuestions { get; set; }
        public List<Essay>? Essays { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateSubmit { get; set; }
    }
}
