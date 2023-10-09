using LibraryApp.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Dto
{
    public class LectureDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int TopicId { get; set; }

        public List<IFormFile> File { get; set; }

    }
}
