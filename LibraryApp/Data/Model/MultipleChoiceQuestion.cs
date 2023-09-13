using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryApp.Data.Model
{
    public class MultipleChoiceQuestion
    {

        [Key]
        public int MultipleChoiceQuestionId { get; set; }

        public string? Question { get; set; }

        public List<Choice>? Choices { get; set; }
        public string? CorrectAnswer { get; set; }
        public int ExamId { get; set; }

        [JsonIgnore]
        public Exam Exam { get; set; }

    }
}
