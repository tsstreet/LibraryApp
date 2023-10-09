using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Dto
{
    public class DocumentDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateSubmit { get; set; }
        public string? Note { get; set; }

    }
}
