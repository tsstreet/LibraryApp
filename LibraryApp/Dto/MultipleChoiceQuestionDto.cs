using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryApp.Data.Dto
{
    public class MultipleChoiceQuestionDto
    {
        public string? Question { get; set; }

        public List<ChoiceDto>? Choices { get; set; }
        public string? CorrectAnswer { get; set; }

    }
}
