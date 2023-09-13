using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryApp.Data.Dto
{
    public class EssayDto
    {
        public string? Question { get; set; }
        public string? AnswerType { get; set; }

    }
}
