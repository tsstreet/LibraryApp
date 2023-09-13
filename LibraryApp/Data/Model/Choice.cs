using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryApp.Data.Model
{
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }

        public string? Value { get; set; }

        public int MultipleChoiceQuestionId { get; set; }

        [JsonIgnore]
        public MultipleChoiceQuestion MultipleChoiceQuestions { get; set; }
    }
}
