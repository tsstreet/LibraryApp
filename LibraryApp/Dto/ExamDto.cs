using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Dto
{
    public class ExamDto
    {
        [Required]
        public string Name { get; set; }


        [Required]
        public string Form { get; set; }

        [Required]
        public string Creator { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]

        public int DepartmentId { get; set; }

        [Required]

        public int SubjectId { get; set; }

        public List<MultipleChoiceQuestionDto>? MultipleChoiceQuestions { get; set; }

        public List<EssayDto>? Essays { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateSubmit { get; set; }
    }
}
