using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class PrivateFile
    {
        [Key]
        public int PrivateFileId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public string? Modifier { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime LastEdited { get; set; }

        [Required]
        public string? Size { get; set; }

        [NotMapped]
        public List<IFormFile> File { get; set; }

        public string? FileType { get; set; }
    }
}
