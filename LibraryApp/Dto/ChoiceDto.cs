using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryApp.Data.Dto
{
    public class ChoiceDto
    {
        public string? Value { get; set; }

    }
}
