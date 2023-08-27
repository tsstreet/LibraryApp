using LibraryApp.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Dto
{
    public class LectureFileDto
    {
        [Key]
        public int LectureFileId { get; set; }


        [Required]
        public int SubjectId { get; set; }

        [Required]
        public string? Name { get; set; }

        public IFormFile File { get; set; }

    }
}
