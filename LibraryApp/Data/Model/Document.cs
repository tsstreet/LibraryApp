using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateSubmit { get; set; }

        [Required]
        public string? Status { get; set; } = "waiting";

        public string? Note { get; set; }

        [Required]
        public bool IsApproved { get; set; } = false;
    }
}
