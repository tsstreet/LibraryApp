using LibraryApp.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Dto
{
    public class TopicDto
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public int SubjectId { get; set; }

    }
}
