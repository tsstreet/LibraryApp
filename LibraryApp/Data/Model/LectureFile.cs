using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class LectureFile
    {
        [Key]
        public int LectureFileId { get; set; }


        [Required]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }
        
      
        [Required]
        public string? Name { get; set; }

        [NotMapped]
        public List<IFormFile>File { get; set; }

        public string? Size { get; set; }

        public string? FileType { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime SubmitDate { get; set; }
  
    }
}
