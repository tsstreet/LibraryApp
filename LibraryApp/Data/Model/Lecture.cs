using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }

        [Required]
        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        public string? FileName { get; set; }

        [NotMapped]
        public List<IFormFile>File { get; set; }

        public string? Size { get; set; }

        public string? FileType { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime SubmitDate { get; set; }
  
    }
}
