using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }

        [Required]
        public string Value { get; set; }

        public int MultipleChoiceQuestionId { get; set; }

        [JsonIgnore]
        public MultipleChoiceQuestion MultipleChoiceQuestions { get; set; }
    }
}
